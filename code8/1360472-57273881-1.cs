	bool[][] GeneratePermutations(int size)
	{
		return Enumerable.Range(0, (int)Math.Pow(2, size))
			.Select(i =>
				Enumerable.Range(0, size)
					.Select(b => ((i & (1 << b)) > 0))
					.ToArray()
			).ToArray();
	}
