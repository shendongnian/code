	var dict = new Dictionary<string, string>
	{
		{"1", "test1"},
		{"2", "test2"},
		{"3", "test1"}
	};
	
	var groupedKeyMap = dict.GroupBy(x => x.Value)
	                        .Where(x => x.Count() > 1)
			                .ToDictionary(x => string.Join("-", x.SelectMany(y => y.Key)),
			                              x => x.Key);
