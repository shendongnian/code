    using System;
    using System.Linq;
    namespace RepeatArray
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] a = { "1", "2", "3", "4", "5" };
                string[] newArray = Enumerable.Repeat(a, 3).SelectMany(x => x).ToArray();
                var pressKeyToExit = Console.ReadKey();
            }
        }
    }
