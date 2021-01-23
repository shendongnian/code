    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n, i, x = 0, y = 0;
                Console.WriteLine("Enter the degree of matrix:");
                n = int.Parse(Console.ReadLine());
                int[,] num = new int[n, n];
                int p = n * n;
                for (i = 1; i <= p; i++)
                {
                    try
                    {
                        num[x, y] = i;
                        if (num[x, y] % n == 0) { y++; continue; }
                        if (y % 2 == 0) { x++; }
                        if (y % 2 != 0) { x--; }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                for (i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(num[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
