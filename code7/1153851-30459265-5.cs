	public IEnumerable<string> ShuffleItems(IEnumerable<string> items)
	{
		var rnd = new Random();
		return items.OrderBy(item => rnd.Next()).ToList();
	}
