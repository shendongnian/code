	var regex = new Regex(@"
		\G(?:
		  (?<string> ""(?>[^""\\]+|\\.)*"" )
		| (?<separator> ; )
		| (?<whitespace> \s+ )
		| (?<invalid> . )
		)
	", RegexOptions.IgnorePatternWhitespace);
	var input = "; \"social life\"; \"city life\"; \"real life\"";
	var groupNames = regex.GetGroupNames().Skip(1).ToList();
	foreach (Match match in regex.Matches(input))
	{
		var groupName = groupNames.Single(name => match.Groups[name].Success);
		var group = match.Groups[groupName];
		Console.WriteLine("{0}: {1}", groupName, group.Value);
	}
	
