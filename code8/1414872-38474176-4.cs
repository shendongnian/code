    public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
    {
        bool didYield = false;
        foreach (var item in enumerable ?? Enumerable.Empty<T>())
        {
            didYield = true;
            yield return item;
        }
        if (!didYield)
        {
            foreach (var item in defaultEnumerable ?? Enumerable.Empty<T>())
                yield return item;
        }
    }
