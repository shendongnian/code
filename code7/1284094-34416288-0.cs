    public void ParseAndApply(Dictionary<string, string> dictionary, string text)
    {
    	foreach (string element in text.Split(';'))
    	{
    		string[] parts = element.Split(new char[]{ ':' }, 2);
    		dictionary[parts[0]] = parts[1];
    	}
    }
    
    public string ConvertToString(Dictionary<string, string> dictionary)
    {
    	return string.Join(";", dictionary.Select(kv => kv.Key + ":" + kv.Value));
    }
