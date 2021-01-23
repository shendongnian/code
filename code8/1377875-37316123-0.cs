    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var rands = genRands(100, 6);
                foreach (var num in rands.Select((n, i) => new { i= i + 1, n }))
                { Console.WriteLine(string.Format("[{0}] {1}", num.i, num.n));};
                Console.ReadLine();
            }
            private static List<int> genRands(int max, int total)
            {
                var nums = new List<int>();
                Random r = new Random();
                for (int i = 0; i < total; i++)
                    nums.Add(r.Next(0, max));
                return nums;
            }
        }
    }
