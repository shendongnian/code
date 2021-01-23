    List<string> output = new List<string>();
    string input = "(\"always use\" OR \"bar\") OR (\"Hello\" AND \"market cost\")";
    string[] firstSplit = input.Split('"');
    for (int i = 0; i < firstSplit.Length; i++)
    {
    	firstSplit[i] = firstSplit[i].Trim();
        // in case of the ') OR (' which has be splitted too
    	if (firstSplit[i].Contains(")") && firstSplit[i].Contains("("))
    	{
    		string[] secondSplit = firstSplit[i].Split(' ');
    		for (int j = 0; j < secondSplit.Length; j++)
    		{
    			output.Add(secondSplit[j]);
    		}
    	}
    	else
    	{
    		output.Add(firstSplit[i]);
    	}
    }
