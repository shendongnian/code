    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            public static void Main()
            {
                string[] test = {"A", "B", "C", "D"};
                foreach (var perm in PermuteWithRepeats(test))
                    Console.WriteLine(string.Join(" ", perm));
            }
            public static IEnumerable<IEnumerable<T>> PermuteWithRepeats<T>(IEnumerable<T> sequence)
            {
                return permuteWithRepeats(sequence, sequence.Count());
            }
            private static IEnumerable<IEnumerable<T>> permuteWithRepeats<T>(IEnumerable<T> sequence, int count)
            {
                if (count == 0)
                {
                    yield return Enumerable.Empty<T>();
                }
                else
                {
                    foreach (T startingElement in sequence)
                    {
                        IEnumerable<T> remainingItems = sequence;
                        foreach (IEnumerable<T> permutationOfRemainder in permuteWithRepeats(remainingItems, count - 1))
                            yield return new[]{startingElement}.Concat(permutationOfRemainder);
                    }
                }
            }
        }
    }
