    string wordtoFind = "try";
    string test = "this try that, but it can have multiple try in that";
    string pattern = @"(?:^\W*|(?<before>\w+)\W+)" + Regex.Escape(wordtoFind) + @"(?:\W+(?<after>\w+)|\W*$)";
	MatchCollection matches = Regex.Matches(test, pattern);
		
	for (int z = 0; z < matches.Count; z++)
	{
	     string error = matches[z].Groups["before"].ToString() + "-" +wordtoFind + "-" + matches[z].Groups["after"].ToString();
	     Console.WriteLine(error);
	}
