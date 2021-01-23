    var items = new List<string[]>() 
		{ 
			new []{"1", "2", "3" ,"4" }, 
			new []{"4","3", "2", "1"},
			new []{"1", "2"}
		};
    var results = items
			.GroupBy(i => i, new UnorderedEnumerableComparer<string>())
			.ToDictionary(g => g.Key, g => g.Count());
