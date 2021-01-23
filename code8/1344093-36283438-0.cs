    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                test(1, 3, 3, 0, 3); // Prints 1, 2
                test(3, 3, 0, 1, 2); // Prints 0, 1
            }
            static void test(params int[] array)
            {
                var indices = Enumerable.Range(0, array.Length).ToArray();
                Array.Sort(array, indices, Comparer<int>.Create((a,b)=>b-a));
                Console.WriteLine($"{indices[0]}, {indices[1]}");
            }
        }
    }
