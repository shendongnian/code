        using System;
        using System.Collections.Generic;
        using System.Linq;
        namespace ConsoleApplication1
        {
            class Program
            {
                public static void Main()
                {
                    foreach (var combination in Combinator(new [] { "T", "F", "U" }, 2))
                        Console.WriteLine(string.Concat(combination));
                }
                public static IEnumerable<IEnumerable<T>> Combinator<T>(IEnumerable<T> sequence, int count)
                {
                    if (count == 0)
                    {
                        yield return Enumerable.Empty<T>();
                        yield break;
                    }
                    foreach (T startingElement in sequence)
                    {
                        IEnumerable<T> remainingItems = sequence;
                        foreach (IEnumerable<T> permutationOfRemainder in Combinator(remainingItems, count - 1))
                            yield return permutationOfRemainder.Concat(new [] { startingElement});
                    }
                }
            }
        }
