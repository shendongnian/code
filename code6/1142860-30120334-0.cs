    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class MyObject
        {
            public int Id;
            public int OperationId;
        }
        static class Program
        {
            [STAThread]
            private static void Main()
            {
                IEnumerable<MyObject> items =
                    new List<MyObject>
                    {
                        new MyObject{Id = 1, OperationId = 1},
                        new MyObject{Id = 1, OperationId = 2},
                        new MyObject{Id = 2, OperationId = 1},
                        new MyObject{Id = 2, OperationId = 2},
                        new MyObject{Id = 3, OperationId = 2}
                    };
                var result = items.GroupBy(item => item.Id).Select(x => x.MaxBy(y => y.OperationId));
            }
        }
        public static class EnumerableMaxMinExt
        {
            public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
            {
                return source.MaxBy(selector, Comparer<TKey>.Default);
            }
            public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
            {
                using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
                {
                    if (!sourceIterator.MoveNext())
                    {
                        throw new InvalidOperationException("Sequence was empty");
                    }
                    TSource max = sourceIterator.Current;
                    TKey maxKey = selector(max);
                    while (sourceIterator.MoveNext())
                    {
                        TSource candidate = sourceIterator.Current;
                        TKey candidateProjected = selector(candidate);
                        if (comparer.Compare(candidateProjected, maxKey) > 0)
                        {
                            max    = candidate;
                            maxKey = candidateProjected;
                        }
                    }
                    return max;
                }
            }
        }
    }
