	public static T GetNext<T>(this IQueryable<T> list, T current)
	{
		try
		{
			int idx = 0;
			foreach (T item in list)
			{
				if (!item.Equals(current))
				{
					idx++;
				}
				else
				{
					break;
				}
			}
			return list.Skip(idx).First();
		}
		catch
		{
			return default(T);
		}
	}
	public static T GetPrevious<T>(this IQueryable<T> list, T current)
	{
		try
		{
			int idx = 0;
			foreach (T item in list)
			{
				if (!item.Equals(current))
				{
					idx++;
				}
				else
				{
					break;
				}
			}
			if (idx - 1 == 0)
				return list.First();
			return list.Skip(idx - 1).First();
		}
		catch
		{
			return default(T);
		}
	}
