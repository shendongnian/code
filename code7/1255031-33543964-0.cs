	public static IEnumerable<int> Sort(int[] ints)
	{
		var dictionary = new Dictionary<int, bool>();
		
		foreach (var i in ints)
		{
		    dictionary.Add(i, false);
		}
		
		return dictionary.Keys;
	}
