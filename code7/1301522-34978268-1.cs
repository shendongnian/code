	public static void Add<T>(this List<T> list, T? item) where T : struct
	{
		if (item.HasValue)
		{
			list.Add(item.Value);
		}
	}
