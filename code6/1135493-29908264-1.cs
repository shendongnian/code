	private Dictionary<string, int> map = new Dictionary<string, int>()
	{
		{ "twix", _numTwix },
		{ "snickers", _numSnickers },
		{ "kitkat", _numKitKat },
	};
		
	public int NumCandyBars (string candyBar)
	{
		return map.ContainsKey(candyBar) ? map[candyBar] : 0;
	}
	public void SomeMethod()
	{
		map["mars"] = 42;
	}
