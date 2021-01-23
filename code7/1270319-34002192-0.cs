    private static string[] ParseArguments(string text)
    {
    	if (string.IsNullOrWhiteSpace(text)) return new string[0];
    	var entries = new List<string>(8);
    	var stringBuilder = new StringBuilder(64);
    	var inString  = false;
    	var l = text.Length;
    	for (var i = 0; i < l; i++)
    	{
    		var c = text[i];
    		if (inString)
    		{
    			if (c == '"')
    			{
    				if (i != l - 1 && text[i + 1] == '"')
    				{
    					stringBuilder.Append(c);
    					i++;
    				}
    				else inString = false;
    			}
    			else stringBuilder.Append(c);
    		}
    		else if (c == '"') inString = true;
    		else if (char.IsWhiteSpace(c))
    		{
    			if (stringBuilder.Length == 0) continue;
    			entries.Add(stringBuilder.ToString());
    			stringBuilder.Length = 0;
    		}
    		else stringBuilder.Append(c);
    	}
    	if (stringBuilder.Length != 0) entries.Add(stringBuilder.ToString());
    	return entries.ToArray();
    }
