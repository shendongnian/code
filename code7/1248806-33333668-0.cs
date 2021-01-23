    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> li = new List<int>();
                for (int i = 1; i <= 1000; i++) 
                {
                    if (i%3 == 0 && i%5 == 0) 
                    {
                        li.Add(i);
                    }
                }
                Console.Write("sum is " + li.Sum());
                Console.ReadLine();
            }
        }
    }
