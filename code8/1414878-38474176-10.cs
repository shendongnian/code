    public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
    {
        bool didYield = false;
        if (enumerable != null)
        {
            foreach (var item in enumerable)
            {
                didYield = true;
                yield return item;
            }
        }
        if (!didYield && defaultEnumerable != null)
        {
            foreach (var item in defaultEnumerable)
                yield return item;
        }
    }
