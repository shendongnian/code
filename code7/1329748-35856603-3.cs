	try
	{
		var regexObj = new Regex("(?<title>.*?)(?:\n{2})(?<paragraph>^.*?\n{2})",
			RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
		var match = regexObj.Match(text);
		while (match.Success)
		{
			var title = match.Groups["title"].Value;
			var paragraph = match.Groups["paragraph"].Value;
			Console.WriteLine("Title: " + title);
			Console.WriteLine();
			Console.WriteLine("Paragraph:\n" + paragraph.Trim());
			Console.WriteLine();
			Console.WriteLine();
			match = match.NextMatch();
		}
	}
	catch (ArgumentException ex)
	{
	}
