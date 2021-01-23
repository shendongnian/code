	IEnumerable<Tuple<int, int, int>> Get()
	{
		for (int i = 0; i < 10; i++)
		{
			yield return Tuple.Create(i, 0, 0);
		}
	}
	IEnumerable<Tuple<int, int, int>> Modify(IEnumerable<Tuple<int, int, int>> tuples)
	{
		foreach (var tuple in tuples)
		{
			if (tuple.Item1 < 5)
			{
				yield return Tuple.Create(tuple.Item1, tuple.Item2 + 1, tuple.Item3);
			}
			else
			{
				yield return Tuple.Create(tuple.Item1, tuple.Item2, tuple.Item3 + 1);
			}
		}
	}
