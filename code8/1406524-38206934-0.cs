    Dictionary<string, string> test = new Dictionary<string, string>();
	test.Add("12342", "F650");
	test.Add("12341", "F000");
	test.Add("12340", "F650");
	test.Add("12343", "0E0E");
	var result = test;
	var filteredResults = new List<KeyValuePair<string, string>>();
	string searchCriteria = "F000,0E0E";
	foreach (string tsearchCritera in searchCriteria.Split(','))
	{
		string temp = tsearchCritera;
		filteredResults.AddRange(result.Where(a => a.Value.Equals(temp)));
	}
	filteredResults.Select(a => a.Key).Dump();
