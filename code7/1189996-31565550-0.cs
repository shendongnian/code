	public static T? FirstOrNull<T>(this IEnumerable<T> items, Predicate<T> predicate) where T : struct
	{
		foreach(var item in items)
		{
			if (predicate(item))
				return item;
		}
		
		return null;
	}
