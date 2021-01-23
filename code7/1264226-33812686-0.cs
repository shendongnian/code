	string[] arrayOne = {"One", "Two", "Three", "Three", "Three"};
	string[] arrayTwo = {"One", "Two", "Three"};
	
	var groupedTwo = arrayTwo
		.GroupBy(g => g)
		.ToDictionary(g => g.Key, g => g.Count());
	var groupedResult = arrayOne
		.GroupBy(a => a)
		.Select(g => new {g.Key, Count = g.Count()})
		.Select(g => new {g.Key, Residual = g.Count - 
           (groupedTwo.ContainsKey(g.Key) ? groupedTwo[g.Key] : 0)})
		.SelectMany(g => Enumerable.Repeat(g.Key, g.Residual));
	foreach (string s in groupedResult) 
	{
	   Console.WriteLine(s);
	}
