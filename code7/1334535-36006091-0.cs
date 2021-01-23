    public static class EnumerableExtensions
    {
        [Pure]
        public static IEnumerable<T[]> Split<T>(this IEnumerable<T> source, int chunkSize)
        {
            T[] sourceArray = source as T[] ?? source.ToArray();
            for (int i = 0; i < sourceArray.Length; i += chunkSize)
            {
                T[] chunk = new T[chunkSize + i > sourceArray.Length ? sourceArray.Length - i : chunkSize];
                Array.Copy(sourceArray, i, chunk, 0, chunk.Length);
                yield return chunk;
            }
        }
    }
