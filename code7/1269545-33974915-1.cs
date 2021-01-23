    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Tst001
    {
        static int[,] showArray = new int[20, 20];
        static int countLeft = 0;
        static int countRight = 0;
        static int leftCount = 0;
        static int rightCount = 0;
        static int leftOver = 0;
        static int a = 0;
        static int b = 0;
        static string[,] Walk = new string[20, 20];
        public static void Main(string[] args)
        {
            int moveCommand;
            for (int x = 0; x < showArray.GetLength(0); x++)//Determine all values to be 0s
            {
                for (int y = 0; y < showArray.GetLength(1); y++)
                {
                    showArray[x, y] = 0;
                }
            }
            DisplayCommand();
            do
            {
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine();
                string[] cmdArray = cmd.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                moveCommand = Convert.ToInt16(cmdArray[0]);
                if (cmdArray.Count() == 2)
                {
                    leftOver = Convert.ToInt16(cmdArray[1]);
                }
                switch (moveCommand)
                {
                    case 2:
                        break;
                    case 3:
                        MoveLeftRight(moveCommand, leftOver);
                        break;
                    case 4:
                        MoveLeftRight(moveCommand, leftOver);
                        break;
                    case 5:
                        Pass(moveCommand, leftOver);
                        break;
                    case 6:
                        DrawArrow();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Wrong number entered!!!");
                        break;
                }
                //Console.WriteLine("leftCount {0}\trightCount {1}\ta {2}\tb {3}\ncountLeft {4}\tcountRight {5}\nDirections {6}", leftCount, rightCount, a, b, countLeft, countRight, Directions(countLeft,countRight)); //Just for checking values
            } while (moveCommand != 9);
            Console.Read();
        }
        public static string Directions(int x, int y) //Determine directions, V for vertical, H for horizontal
        {
            string[,] Direction = { {"-V","H","V","-H" },
                                  {"-H","-V","H","V" },
                                  {"V","-H","-V","H" },
                                  {"H","V","-H","-V" }};
            return Direction[x, y];
        }
        public static void MoveLeftRight(int moveCommand, int count)
        {
            if (moveCommand == 3 || moveCommand == 4)//Determine the directions
            {
                if (moveCommand == 3)
                {
                    rightCount++;
                    countRight = count;
                }
                else
                {
                    leftCount++;
                    countLeft = count;
                }
            }
        }
        public static void Pass(int moveCommand, int leftOver)
        {
            if (leftOver >= 20)
            {
                Console.WriteLine("Exceed limit of array!");
            }
            else if (leftOver < 20)
            {
                if (Directions(countLeft, countRight) == "-V")
                {
                    if (a - (int)leftOver >= 0)
                    {
                        a -= (int)leftOver;
                    }
                    else
                    {
                        Console.WriteLine("Exceed limit of array! Do not enter more than {0} passes!", a);
                    }
                }
                else if (Directions(countLeft, countRight) == "V")
                {
                    if (a + (int)leftOver < 20)
                    {
                        a += (int)leftOver;
                    }
                    else
                    {
                        Console.WriteLine("Exceed limit of array! Do not enter more than {0} passes!", (19 - a));
                    }
                }
                else if (Directions(countLeft, countRight) == "-H")
                {
                    if (b - (int)leftOver >= 0)
                    {
                        b -= (int)leftOver;
                    }
                    else
                    {
                        Console.WriteLine("Exceed limit of array! Do not enter more than {0} passes!", b);
                    }
                }
                else
                {
                    if (b + (int)leftOver < 20)
                    {
                        b += (int)leftOver;
                    }
                    else
                    {
                        Console.WriteLine("Exceed limit of array! Do not enter more than {0} passes!", (19 - b));
                    }
                }
            }
        }
        public static void DrawArrow()
        {
            for (int x = 0; x < Walk.GetLength(0); x++)
            {
                for (int y = 0; y < Walk.GetLength(1); y++)
                {
                    if (showArray[x, y] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void DisplayCommand()
        {
            Console.WriteLine("Enter 3 to move Right,\n" +
               "Enter 4 to move Left,\n" +
               "Enter 5,x to determine amount of passes\n" +
               "Enter 2 to move pencil down,\n" +
               "Enter 1 to move pencil up,\n" +
               "Enter 6 to draw the array,\n" +
               "Enter 9 to end the program!\n");
        }
    }​
