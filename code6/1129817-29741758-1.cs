    private static string GetHighestFolderVersion()
    {
    
    	string startFolder = @"C:\Version\";
    	System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
    	IEnumerable<System.IO.DirectoryInfo> directoryList = dir.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);
    
    	KeyValuePair<string, long> highestVersion = new KeyValuePair<string, long>("", 0);
    	foreach (System.IO.DirectoryInfo dirInfo in directoryList)
    	{
    		string versionOrigName = dirInfo.Name;
    		string versionStr = versionOrigName.Substring(1);
    		List<string> versionParts = versionStr.Split('_').ToList<string>();
    
    		long versionVal = 0;
    		int exp = 0;
    		for (int i = versionParts.Count - 1; i > -1; i--)
    		{
    			versionVal += (long.Parse(versionParts[i]) * (long)(Math.Pow(1000, exp)));
    			exp++;
    		}
    
    		if (versionVal > highestVersion.Value)
    		{
    			highestVersion = new KeyValuePair<string, long>(versionOrigName, versionVal);
    		}
    	}
    
    	return highestVersion.Key;
    }
