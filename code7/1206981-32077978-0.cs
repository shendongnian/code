    private static String Replace(String str)
    {
        var dictionary = new Dictionary<string, string>
        {
            {"primaryColour", "blue"},
            {"secondaryColour", "red"}
        };
    
        string pattern = @"@Model\.(?<name>\w+)";
    	return Regex.Replace(str, pattern, m => 
    		{
    			string key = m.Groups["name"].Value;
    			key = FirstCharacterToLower(key);
    			string value = null;
    			if (dictionary.TryGetValue(key, out value))
    				return value;
    			else
    				return m.Value;
    		});
    }
