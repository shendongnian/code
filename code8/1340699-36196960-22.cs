    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                int target = 100;
                test(85, 35, 25, 45, 16, 100);   // Prints 100: 100
                test(55, 75, 26, 55, 99);        // Prints 101: 75, 26
                test(99, 15, 66, 75, 85, 88, 5); // Prints 100: 15, 85
                test(1, 1, 1, 1, 1);             // Prints 0: 
            }
            static void test(params int[] a)
            {
                var result = FindClosest(a, 100);
                if (result != null)
                    Console.WriteLine(result.Sum() + ": " + string.Join(", ", result));
                else
                    Console.WriteLine("No result found for: " + string.Join(", ", a));
            }
            public static IEnumerable<int> FindClosest(int[] array, int target)
            {
                return Combinations(array)
                    .Where(c => c.Sum() >= target)
                    .MinByOrDefault(c => c.Sum());
            }
            public static IEnumerable<IEnumerable<T>> Combinations<T>(T[] array)
            {
                uint max = 1u << array.Length;
                for (uint i = 1; i < max; ++i)
                    yield return select(array, i, max);
            }
            static IEnumerable<T> select<T>(T[] array, uint bits, uint max)
            {
                for (int i = 0, bit = 1; bit < max; bit <<= 1, ++i)
                    if ((bits & bit) != 0)
                        yield return array[i];
            }
            public static TSource MinByOrDefault<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
            {
                return source.MinByOrDefault(selector, Comparer<TKey>.Default);
            }
            public static TSource MinByOrDefault<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
            {
                using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
                {
                    if (!sourceIterator.MoveNext())
                        return default(TSource);
                    TSource min = sourceIterator.Current;
                    TKey minKey = selector(min);
                    while (sourceIterator.MoveNext())
                    {
                        TSource candidate = sourceIterator.Current;
                        TKey candidateProjected = selector(candidate);
                        if (comparer.Compare(candidateProjected, minKey) < 0)
                        {
                            min = candidate;
                            minKey = candidateProjected;
                        }
                    }
                    return min;
                }
            }
        }
    }
