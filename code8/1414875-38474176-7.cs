	public static IEnumerable<T> DefaultEnumerableIfEmpty<T>(this IEnumerable<T> enumerable, IEnumerable<T> defaultEnumerable)
	{
	    if (enumerable == null)
			return defaultEnumerable;
		List<T> items = enumerable.ToList(); // enumerate it once
		if (items.Count == 0)
			return defaultEnumerable;
		return items;
	}
