    public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
    {
        bool didYield = false;
        foreach (var item in enumerable)
        {
            didYield = true;
            yield return item;
        }
        if (!didYield)
        {
            foreach (var item in defaultEnumerable)
                yield return item;
        }
    }
