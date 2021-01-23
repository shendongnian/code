	public IEnumerable<Item> GetItems()
	{
		return
			new [] { this }
				.Concat(this.Children.SelectMany(i => i.GetItems()));
	}
	public IEnumerable<Item> GetItems()
	{
		yield return this;
		foreach (var descendent in this.Children.SelectMany(i => i.GetItems()))
		{
			yield return descendent;
		}
	}
