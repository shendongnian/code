	public static void AddIfNotNull<T>(this List<T> list, T? value)
	{
		if(value != null)
		{
			list.Add(value.Value);
		}
	}
	
