	public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
	{
	    if (enumerable == null)
			return defaultEnumerable;
        var enumerator = enumerable.GetEnumerator();
        if (enumerator.MoveNext())
            return CombineBack(enumerator);
        return defaultEnumerable;
	}
    private static IEnumerable<T> CombineBack<T>(IEnumerator<T> enumerator)
    {
        yield return enumerator.Current;
        while (enumerator.MoveNext())
            yield return enumerator.Current;
    }
