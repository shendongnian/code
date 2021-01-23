    public static IEnumerable<IEnumerable<T>> GroupBatch<T>(this IEnumerable<T> enumerable, int batchSize)
    {
        int count = enumerable.Count();
        for (int taken = 0; taken < count ; taken += batchSize)
        {
            yield return enumerable.Skip(taken).Take(batchSize);
        }
    }
