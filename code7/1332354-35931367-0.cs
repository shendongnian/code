	List<string> history = new List<string>(){ "AA", "BB", "CC", "AA" };
	List<string> potentialNew = new List<string>(){ "CC", "AA", "DD", "EE", "FF", "AA"};
	
	potentialNew.Aggregate(history, (h, p) =>
	{
		if (!h.Skip(h.Count - 2).Contains(p))
		{
			h.Add(p);
		}
		return h;
	});
