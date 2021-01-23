	public static string removeDuplicateCharacters(String text, int allowedDuplicates)
	{
		string seen="";
		Dictionary<char, int> charCount = new 	Dictionary<char, int>();
		foreach (char c in text)
		{
			if(!charCount.ContainsKey(c))
			{
				seen += c;
				charCount.Add(c, 1);
			}
			else if(charCount[c] < allowedDuplicates)
			{
				charCount[c] += 1;
				seen += c;
			}
			else
			{
				//Reached max, do nothing
			}
        }
		return seen; 
	 }      
