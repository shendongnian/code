        public static class EnumerableExtensions
        {
            /// <summary>
            /// This one works using existing linq methods.
            /// </summary>
            public static IEnumerable<T> GetRange<T>(this IEnumerable<T> source, Func<T, bool> isStart, Func<T, bool> isStop)
            {
                var provideExtraItem = new[] { true, false };
                return source
                    .SkipWhile(i => !isStart(i))
                    .SelectMany(i => provideExtraItem, (item, useThisOne) => new {item, useThisOne })
                    .TakeWhile(i => i.useThisOne || !isStop(i.item))
                    .Where(i => i.useThisOne)
                    .Select(i => i.item);
            }
    
            /// <summary>
            /// This one is probably a bit faster.
            /// </summary>
            public static IEnumerable<T> GetRangeUsingIterator<T>(this IEnumerable<T> source, Func<T, bool> isStart, Func<T, bool> isStop)
            {
                using (var iterator = source.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        if (isStart(iterator.Current))
                        {
                            yield return iterator.Current;
                            break;
                        }
                    }
                    while (iterator.MoveNext())
                    {
                        yield return iterator.Current;
                        if (isStop(iterator.Current))
                            break;
                    }
                }
            }
        }
