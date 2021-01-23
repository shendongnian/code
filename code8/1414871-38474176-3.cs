    public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
    {
        if (enumerable == null || !enumerable.Any())
            return defaultEnumerable;
        return enumerable ?? Enumerable.Empty<T>();
    }
