	public static IEnumerable<T> Skip<T>(this IList<T> list, int count)
	{
		for (var i = count; i < list.Count; i++)
			yield return list[i];
	}
