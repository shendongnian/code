	public int NumCandyBars (string candyBar)
	{
		var map = new Dictionary<string, int>()
		{
			{ "twix", _numTwix },
			{ "snickers", _numSnickers },
			{ "kitkat", _numKitKat },
		};
		
		return map.ContainsKey(candyBar) ? map[candyBar] : 0;
	}
