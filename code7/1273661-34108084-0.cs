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
                { 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
                ,{ 1, 2,3,4,5,6,7,8 }
            };
    
            static void Main(string[] args)
            {
                var width = Console.WindowWidth;
                var height = Console.WindowHeight;
    
                int header_left = (width - "0 1 2 3 4 5 6 7".Length)/2;
                int body_left = (width - "0 1 2 3 4 5 6 7 1".Length) / 2;
    
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorLeft = header_left;
                Console.WriteLine("0 1 2 3 4 5 6 7");
                Console.ResetColor();
                for (int i = 0; i < 8; i++)
                {
                    Console.CursorLeft = body_left;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("{0,2}",BoardDisplay[j, i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" {0}",i);
                    Console.ResetColor();
                }
                Console.ReadKey();
            }
    
        }
    }
     
