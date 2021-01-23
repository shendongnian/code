	public static void AddIfNotNull<T>(this List<T> list, T? value) where T : struct
	{
		if(value != null)
		{
			list.Add(value.Value);
		}
	}
	
