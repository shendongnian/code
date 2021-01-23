	public static IDictionary<DateTime, int> ShiftContent(
			this IDictionary<DateTime, int> inputDictionary, int size)
	{		
		return 
			Enumerable.Range(1, size).Select(value => new KeyValuePair<DateTime, int>(inputDictionary.First().Key.AddMonths(value - 1), 0))		
			.Union(inputDictionary.ToList().Select(value => new KeyValuePair<DateTime, int>(value.Key.AddMonths(size), value.Value)))
			.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
	}
