    using System;
    namespace x
    {
        class Program
        {
            static void Main()
            {
                var alb = new[] { "B","Z","C","E","T" };
                int[] orderedIndexes = {0, 3, 4, 1, 2};
                for (var i = 0; i < orderedIndexes.Length; i++)
                {
                    var ts = alb[i];
                    alb[i] = alb[orderedIndexes[i]];
                    alb[orderedIndexes[i]] = ts;
                    orderedIndexes[orderedIndexes[i]] = orderedIndexes[i];
                }
                for (var i = 0; i < orderedIndexes.Length; i++)
                {
                    Console.WriteLine("{0}, {1}", i, alb[i]);
                }
            }
        }
    }
