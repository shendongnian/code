    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            const int COLUMNS = 8;
            const int ROWS = 8;
            const int SIZE = 2;
            static void Main(string[] args)
            {
                double[,] test = {
                    {9, 8, 7, 6, 5, 4, 3, 2},
                    {8, 7, 6, 5, 4, 3, 2, 1},
                    {7, 6, 5, 4, 3, 2, 1, 0},
                    {6, 5, 4, 3, 2, 1, 0, 0},
                    {5, 4, 3, 2, 1, 0, 0, 0},
                    {4, 3, 2, 1, 0, 0, 0, 0},
                    {3, 2, 1, 0, 0, 0, 0, 0},
                    {2, 1, 0, 0, 0, 0, 0, 0},
                };
                for (int i = 0; i < COLUMNS; i += SIZE)
                {
                    for (int j = 0; j < ROWS; j += SIZE)
                    {
                        for (int k = j; k < j + SIZE; k++)
                        {
                            for (int l = i; l < i + SIZE; l++)
                            {
                                Console.WriteLine("test[{0}, {1}] = {2}", k, l, test[k, l]);
                            }
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
