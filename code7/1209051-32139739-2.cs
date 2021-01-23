		public static IEnumerable<IEnumerable<T>> Page<T>(this IEnumerable<T> source, int pageSize)
		{
			T[] sourceArray = source.ToArray();
			int pageCounter = 0;
			while (true)
			{
				if (sourceArray.Length <= pageCounter * pageSize)
				{
					break;
				}
				yield return sourceArray
					.Skip(pageCounter * pageSize)
					.Take(pageSize);
				pageCounter++;
			}
    	}
