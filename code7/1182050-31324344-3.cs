	public static string removeDuplicateCharacters(String text, int allowedDuplicates)
	{
		StringBuilder seen = new StringBuilder();
		Dictionary<char, int> charCount = new 	Dictionary<char, int>();
		foreach (char c in text)
		{
			char upperCase = c.ToUpper();
			if(!charCount.ContainsKey(upperCase))
			{
				seen.Append(c);
				charCount.Add(upperCase , 1);
			}
			else if(charCount[upperCase] < allowedDuplicates)
			{
				charCount[upperCase ] += 1;
				seen.Append(c);
			}
			else
			{
				//Reached max, do nothing
			}
		return seen.ToString(); 
	 }      
