	public static string removeDuplicateCharacters(String text, int allowedDuplicates)
	{
		StringBuilder seen = new StringBuilder();
		Dictionary<char, int> charCount = new 	Dictionary<char, int>();
		foreach (char c in text)
		{
			if(!charCount.ContainsKey(c))
			{
				seen.Append(c);
				charCount.Add(c, 1);
			}
			else if(charCount[c] < allowedDuplicates)
			{
				charCount[c] += 1;
				seen.Append(c);
			}
			else
			{
				//Reached max, do nothing
			}
		return seen.ToString(); 
	 }     
