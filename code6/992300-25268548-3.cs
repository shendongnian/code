    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IList<T> allValues)
    {
        for (int counter = 0; counter < (1 << allValues.Count); ++counter)
            yield return allValues.Where((_, i) => (counter & 1 << i) == 0).ToList();
    }
