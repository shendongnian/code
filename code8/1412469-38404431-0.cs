    using System;
    using System.Collections.Generic;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i <= 100; i++) { list.Add(i); }
            foreach (int value in list)
            {
                Thread thread = new Thread(() => PrintNumberTimesFive(value));
                thread.Start();
            }
            
            Console.ReadLine();
        }
        static void PrintNumberTimesFive(int number)
        {
            Console.WriteLine(number * 5);
        }
    }
