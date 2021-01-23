    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                List<String> items = new List<String>();
                items.AddRange(new String[] { "a", "b", "c", "d", "e", "f" });
                int i = 0;
                foreach (var permutation in Permute(items))
                    Console.WriteLine(++i + ": " + string.Join(" ", permutation));
            }
            public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> sequence)
            {
                return permute(sequence, sequence.Count());
            }
            static IEnumerable<IEnumerable<T>> permute<T>(IEnumerable<T> sequence, int count)
            {
                if (count == 0)
                    yield return new T[0];
                int startingElementIndex = 0;
                foreach (T startingElement in sequence)
                    foreach (var permutationOfRemainder in permute(allExcept(sequence, startingElementIndex++), count - 1))
                        yield return new[] {startingElement}.Concat(permutationOfRemainder);
            }
            static IEnumerable<T> allExcept<T>(IEnumerable<T> input, int indexToSkip)
            {
                int index = 0;
                foreach (T item in input)
                    if (index++ != indexToSkip)
                        yield return item;
            }
        }
    }
