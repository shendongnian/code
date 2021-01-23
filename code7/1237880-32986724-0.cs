    public static string replacement(string oldString, char charToRemove)
	{
		string newString = "";
		bool found = false;
		foreach (char c in oldString)
		{
			if (c == charToRemove && !found)
			{
				found = true;
				continue;
			}
			newString += c;
		}
		return newString;
	}
	
