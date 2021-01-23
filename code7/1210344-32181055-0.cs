	string input = "44sugar1100";
	string pattern = "\\w";            // Split on words
	string[] substrings = Regex.Split(input, pattern);
	foreach (string match in substrings)
	{
	 Console.WriteLine("'{0}'", match);
	}
