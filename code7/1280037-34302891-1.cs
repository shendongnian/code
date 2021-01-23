	private Random rnd = new Random();
	public IEnumerable<int> getValues()
	{
		foreach (var value in Enumerable.Range(0, 26).OrderBy(x => rnd.Next()))
		{
			yield return value;
		}
	}
