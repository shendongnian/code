[store1,store2] as default values for every element:
	Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> dictionaryLevel0 = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>();
	string[,] items = new string[8, 3]
	{
		{"blue", "one", "available"}, {"blue", "two", "available"},
		{"blue", "three", "not available"}, {"black", "six", "not available"}, {"black", "four", "available"}, {"brown", "one", "available"}, {"brown", "seven", "available"},
		{"brown", "six", "not available"}
	};
	for (int i = 0; i <= items.GetUpperBound(0); i++)
	{
		if(!dictionaryLevel0.ContainsKey(items[i, 0]))
			dictionaryLevel0.Add(items[i, 0], new Dictionary<string, Dictionary<string, List<string>>>());
		var dictionaryLevel1 = dictionaryLevel0[items[i, 0]];
		if (!dictionaryLevel1.ContainsKey(items[i, 1]))
			dictionaryLevel1.Add(items[i, 1], new Dictionary<string, List<string>>());
		var dictionaryLevel2 = dictionaryLevel1[items[i, 1]];
		if (!dictionaryLevel2.ContainsKey(items[i, 2]))
			dictionaryLevel2.Add(items[i, 2], new List<string> { "store1", "store2"});
	}
