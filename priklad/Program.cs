//using System;

//class PuzzleGame
//{
//    private int[,] board;//двухмерный массив  для хранения
//    private int emptyRow;//индекс строки пустой ячейки
//    private int emptyCol;//индекс столбца

//    public PuzzleGame()//конструктор инициализируе доску и перемешивает
//    {
//        board = new int[4, 4];//доска 4 на 4
//        InitializeBoard();//заолняет доску
//        ShuffleBoard();//перемешивает плитки для начала
//    }

//    private void InitializeBoard()// Инициализация игрового поля
//    {
//        int num = 1;
//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j < 4; j++)
//            {
//                board[i, j] = (i == 3 && j == 3) ? 0 : num++;
//            }
//        }
//        emptyRow = 3;//устанавливаем позицию пустой ячейки в нижний правый угол
//        emptyCol = 3;
//    }

//    public void PrintBoard()//вывод состояние доски на экран
//    {
//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j < 4; j++)
//            {
//                if (board[i, j] == 0)
//                    Console.Write("_ ");
//                else
//                    Console.Write(board[i, j] + " ");//для пустой ячейки
//            }
//            Console.WriteLine();
//        }
//    }

//    public void Move(char direction)//перемещает плитку если это возможно
//    {
//        int newRow = emptyRow;
//        int newCol = emptyCol;

//        switch (direction)
//        {
//            case 'W':
//                newRow--;//вверх
//                break;
//            case 'S':
//                newRow++;//вних
//                break;
//            case 'A':
//                newCol--;//влево
//                break;
//            case 'D':
//                newCol++;//вправо
//                break;
//            default:
//                Console.WriteLine("Неверное направление!");
//                return;
//        }

//        if (IsValidMove(newRow, newCol))
//        {
//            board[emptyRow, emptyCol] = board[newRow, newCol];//перемещаем плитку  и обновляем позицию пустой ячейки
//            board[newRow, newCol] = 0;
//            emptyRow = newRow;
//            emptyCol = newCol;
//        }
//        else
//        {
//            Console.WriteLine("Неверный ход!");
//        }
//    }

//    public bool CheckWin()//проверяет правильно ли расположены ячейки по порядку
//    {
//        int num = 1;
//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j < 4; j++)
//            {
//                if (i == 3 && j == 3)
//                {
//                    if (board[i, j] != 0)
//                        return false;//проверка что последняя ячейка пуста
//                }
//                else if (board[i, j] != num++)
//                {
//                    return false;//проверка на правильность расположения плиток 
//                }
//            }
//        }
//        return true;//плити правильны
//    }

//    private void ShuffleBoard()//перемешивает плитки
//    {
//        Random rand = new Random();
//        for (int i = 0; i < 1000; i++)
//        {
//            char[] directions = { 'W', 'A', 'S', 'D' };
//            char direction = directions[rand.Next(directions.Length)];
//            Move(direction);//случайное дествие
//        }
//    }

//    private bool IsValidMove(int row, int col)//проверяет попадает ли ячейка в границы
//    {
//        return row >= 0 && row < 4 && col >= 0 && col < 4;
//    }

//    static void Main(string[] args)//тока входа в программу
//    {
//        PuzzleGame game = new PuzzleGame();
//        char command;

//        do
//        {
//            Console.Clear();
//            game.PrintBoard();
//            Console.WriteLine("Введите ход (W - вверх, S - вниз, A - влево, D - вправо, Q - выйти):");
//            command = char.ToUpper(Console.ReadKey(true).KeyChar);//считывает команду

//            if (command != 'Q')
//            {
//                game.Move(command);//выполняет движение
//                if (game.CheckWin())
//                {
//                    Console.Clear();
//                    game.PrintBoard();//выводит доску с результатом 
//                    Console.WriteLine("Поздравляем! Вы выиграли!");
//                    break;
//                }
//            }
//        } while (command != 'Q');//повторяется пока пользователь не введет q

//        Console.WriteLine("Игра окончена.");
//    }
//}