    using System;
    namespace x
    {
        class Program
        {
            static void Main()
            {
                var alb = new[] { "B","Z","C","E","T" };
                int[] orderedIndexes = {2,0,1,4,3};
                for (var i = 0; i < orderedIndexes.Length; i++)
                {
                    var x = orderedIndexes[i];
                    var ts = alb[i];
                    alb[i] = alb[x];
                    alb[x] = ts;
                    x = Array.IndexOf(orderedIndexes, i);
                    var ti = orderedIndexes[i];
                    orderedIndexes[i] = orderedIndexes[x];
                    orderedIndexes[x] = ti;
                }
                for (var i = 0; i < orderedIndexes.Length; i++)
                {
                    Console.WriteLine("{0}, {1}", i, alb[i]);
                }
            }
        }
    }
