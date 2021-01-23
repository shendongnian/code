    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication87
    {
        class Program 
        {
            static void Main(string[] args)
            {
                string input = "abcdef";
                long max = (long)(Math.Pow(2, input.Length) - 1);
                for (long count = 0; count <= max; count++)
                {
                    List<string> array = new List<string>();
                    for (int j = input.Length - 1; j >= 0; j--)
                    {
                        array.Add((count >> j & 1) == 0 ? "0" : "1");
                    }
                    Console.WriteLine(string.Join(" ", array.ToArray()));
                }
                Console.ReadLine();
     
            }
        }
    }
