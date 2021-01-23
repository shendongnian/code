    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static int[,] BoardDisplay = new int[8, 8] { 
                { 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
                ,{ 1,2,3,4,5,6,7,8 }
            };
    
            static void Main(string[] args)
            {
                int space_for_each_cell = 5;
                var width = Console.WindowWidth;
                var height = Console.WindowHeight;
    
                int left = (width - (8* space_for_each_cell)) / 2;
    
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorLeft = left;
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("{0,"+space_for_each_cell+"}", i);
                }
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < 8; i++)
                {
                    Console.CursorLeft = left;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("{0,"+space_for_each_cell+"}", BoardDisplay[j, i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0,"+space_for_each_cell+"}",i);
                    Console.ResetColor();
                }
                Console.ReadKey();
            }
    
        }
    }
     
