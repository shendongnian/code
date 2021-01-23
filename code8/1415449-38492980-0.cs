	public IEnumerable<string> GetCombinations(IEnumerable<string> source)
	{
		if (source == null || !source.Any())
		{
			return Enumerable.Empty<string>();
		}
		else if (source.Skip(1).Any())
		{
			return new string[] { null, source.First() }.SelectMany(x => GetCombinations(source.Skip(1)), (x, y) => x + y);
		}
		else
		{
			return new string[] { null, source.First() };
		}
	}
