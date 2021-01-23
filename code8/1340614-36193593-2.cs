	string keyword = "A-B-C-D";
	string[] keywordSplit = keyword.Split('-');
	int combinations = Convert.ToInt32(Math.Pow(2.0, (double)keywordSplit.Length - 1.0));
	List<string> results = new List<string>();
	for (int j = 0; j < combinations; j++)
	{
		string result = "";
		string hyphenAdded = Convert.ToString(j, 2).PadLeft(keywordSplit.Length - 1, '0');
		// Generate string
		for (int i = 0; i < keywordSplit.Length; i++)
		{
			result += keywordSplit[i] +
					  ((i < keywordSplit.Length - 1) && (hyphenAdded.ToString()[i].Equals('1')) ? "-" : "");
		}
		results.Add(result);
	}
