	static void Main(string[] args)
	{
		string[] blacklist = {"Goodbye","Welcome","join us"};
		string input = "Welcome, come join us at dummywebsite.com for fun and games, goodbye!";
		Regex blacklistRegex = new Regex(GetBlacklistRegexString(blacklist), RegexOptions.IgnoreCase);
		foreach (Match match in blacklistRegex.Matches(input))
		{
			Console.WriteLine(match);
		}
		Console.ReadLine();
	}
