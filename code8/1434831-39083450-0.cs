    public static class EnumerableExtension
    {
        private static IEnumerable<T> GetChunk<T>(IEnumerator<T> source, int size)
        {
            yield return source.Current;
            for (int i = 1; i < size; i++)
            {
                if (source.MoveNext())
                {
                    yield return source.Current;
                }
                else
                {
                    yield break;
                }
            }
        }
        public static IEnumerable<IEnumerable<T>> SplitToChunks<T>(this IEnumerable<T> source, int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return GetChunk(enumerator, size);
                }
            }
        }
    }
