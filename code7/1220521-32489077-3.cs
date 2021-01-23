    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
                var data = new [] {"A", "B", "C", "D"};
                // Get all the combinations of elements from A,B,C,D with between 2 and 3 values:
                var combinations = Combinations(data, 2, 3);
                // Combinations() has returned an IEnumerable<IEnumberable<T>>,
                // that is, a sequence of subsequences where each subsequence is one combination.
                foreach (var combination in combinations)
                    Console.WriteLine(string.Join(",", combination));
            }
            public static IEnumerable<IEnumerable<T>> Combinations<T>(T[] input, int minElements, int maxElements)
            {
                int numCombinations = 2 << (input.Length - 1);
                for (int bits = 0; bits < numCombinations; ++bits)
                {
                    int bitCount = NumBitsSet(bits);
                    if (minElements <= bitCount && bitCount <= maxElements)
                        yield return combination(input, bits);
                }
            }
            private static IEnumerable<T> combination<T>(T[] input, int bits)
            {
                for (int bit = 1, i = 0; i < input.Length; ++i, bit <<= 1)
                    if ((bits & bit) != 0)
                        yield return input[i];
            }
            public static int NumBitsSet(int i)
            {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
            }
        }
    }
