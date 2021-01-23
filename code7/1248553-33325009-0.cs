	public static IEnumerable<int> MaxIndices(this IEnumerable<int> source)
	{
	  using(var en =  myArray.GetEnumerator())
	  {
		if (!en.MoveNext())
		  return Enumerable.Empty<int>();
		int curMax = en.Current;
		List<int> indices = new List<int>{ 0 };
		for (int index = 1; en.MoveNext(); ++index)
		{
		  int current = en.Current;
		  if (current == curMax)
			indices.Add(index);
		  else if (current > curMax)
		  {
			indices.Clear();
			indices.Add(index);
			curMax = current;
		  }
		}
		return indices;
	  }
	}
