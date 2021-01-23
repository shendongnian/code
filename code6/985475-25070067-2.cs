	public T[] Flatten<T>(Array source)
	{
		var arrayIndex = new int[source.Rank];
		var result = new T[Enumerable.Range(0, source.Rank).Sum(i => source.GetUpperBound(i))];
		var index = 0;
		for(var i = 0; i < source.Rank; i++)
		{
			for(var j = 0; j < source.GetUpperBound(i); j++) 
			{
				arrayIndex[i] = j;
				result[index++] = (T)source.GetValue(arrayIndex);
			}
		}
		return result;
	}
