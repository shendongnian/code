	string test = "viv-ek is a good boy.Mah - esh is Cra - zy.";
	test = test.Replace(" -", "-").Replace("- ", "-").Replace(".", ". ");
	string[] allwords = test.Split(' ');
	List<string> extractedWords=new List<string>();
	foreach(string wrd in allwords)
	{
		if(wrd.Contains("-"))
		{
			extractedWords.Add(wrd.Replace("-", ""));
		}
	}
