    public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
    {
        if (enumerable == null || !enumerable.Any())
            return defaultEnumerable ?? Enumerable.Empty<T>();
        return enumerable;
    }
