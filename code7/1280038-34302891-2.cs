	private Random rnd = new Random();
	public IEnumerable<int> getValues()
	{
		return Enumerable.Range(0, 26).OrderBy(x => rnd.Next());
	}
