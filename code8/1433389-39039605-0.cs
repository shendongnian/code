	public static bool NotEmptyAll<T>(
		this IEnumerable<T> collection, 
		Func<T, bool> predicate)
	{
		return collection != null
			&& collection.Any()
			&& collection.All(predicate);
	}
