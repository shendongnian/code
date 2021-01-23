	private static bool IsObjectCompatableWithObjects<T>(T obj, IEnumerable<T> objects)
	{
		foreach (var item in objects)
		{
			if (obj.Equals(item))
			{
				return true;
			}
		}
		return false;
	}
