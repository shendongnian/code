    public string GetMaxVersion(IEnumerable<string> directoryNames)
    {
    	var vDict = directoryNames.ToDictionary(
    		s => new Version(s.Substring(1).Replace("_", ".")),
    		s => s);
    	var maxKey = vDict.Keys.Max();
    	return vDict[maxKey];
    }
