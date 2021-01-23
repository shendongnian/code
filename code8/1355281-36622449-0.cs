	Regex r = new Regex(@"\{(\w+)\s(\w+)\}");
	string input = @"{ {Name Mike} {age 19} {gender male}}";
	string outputTemplate = @"<a text = ""{0}"" value = ""{1}"" />";
	if (r.IsMatch(input))
	{
		foreach (Match match in r.Matches(input))
		{
			string key = match.Groups[1].Captures[0].Value;
			string value = match.Groups[2].Captures[0].Value;
			Console.WriteLine(outputTemplate, key, value);
		}
	}
