	string input = "44sugar1100";
	string pattern = "[a-zA-Z]+";            // Split on any group of letters
	string[] substrings = Regex.Split(input, pattern);
	foreach (string match in substrings)
	{
	    Console.WriteLine("'{0}'", match);
	}
