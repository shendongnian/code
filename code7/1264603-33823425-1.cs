    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            public static void Main()
            {
                string input = "5#9#6#4#6#8#0#7#1#5";
                var numbers = input.Split('#').Select(int.Parse).ToArray();
                int sum = MakeTriangular(numbers).Sum(row => row.Max());
                Console.WriteLine(sum);
            }
            public static IEnumerable<IEnumerable<int>> MakeTriangular(int[] numbers)
            {
                for (int i = 0, len = 1; i < numbers.Length; i += len, ++len)
                    yield return new ArraySegment<int>(numbers, i, len);
            }
        }
    }
