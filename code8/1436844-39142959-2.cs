        public static IEnumreable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            // TODO: Argument validation
            using (var iterator = source.GetEnumerator())
            {
                while (count > 0 && iterator.MoveNext())
                {
                    count--;
                    yield return iterator.Current;
                }
            }
        }
