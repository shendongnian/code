    WebClient client = new WebClient();
	string dictionary = client.DownloadString(
        @"https://raw.githubusercontent.com/dwyl/english-words/master/words.txt");
	Stopwatch watch = new Stopwatch();
	watch.Start();
	HashSet<string> fourLetterWords = new HashSet<string>();
	using (StringReader reader = new StringReader(dictionary))
	{
		while (true)
		{
			string line = reader.ReadLine();
			if (line == null) break;
			if (line.Length != 4) continue;
				
			fourLetterWords.Add(line);
		}
	}
	List<string> matches = new List<string>();
	using (StringReader reader = new StringReader(dictionary))
	{
		while (true)
		{
			string line = reader.ReadLine();
			if (line == null) break;
			if (line.Length != 8) continue;
				
			if (fourLetterWords.Contains(line.Substring(0, 4)) &&
				fourLetterWords.Contains(line.Substring(4, 4)))
				matches.Add(line);
		}
	}
    watch.Stop();    
