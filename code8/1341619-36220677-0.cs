	string input = "ali{}";
	//Regex for Braces
	string BracesRegex = @"\{|\}";
	
	Dictionary<string, string> dictionaryofBraces = new Dictionary<string, string>()
	{
		{"Brace", BracesRegex }
	};
	var matches = dictionaryofBraces.SelectMany(a => Regex.Matches(input, a.Value)
				.Cast<Match>()
				.Select(b => String.Format("{0} {1}", b.Value, a.Key.ToUpper())))
				.OrderBy(a => a).ToList();
	
	foreach (var match in matches)
	{
		Console.WriteLine(match);
	}
