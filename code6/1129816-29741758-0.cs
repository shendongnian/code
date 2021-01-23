    private static string GetHighestFolderVersion()
    {
    
    	string startFolder = @"C:\Version\";
    	System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
    	IEnumerable<System.IO.DirectoryInfo> directoryList = dir.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);
    
    	KeyValuePair<string, int> highestVersion = new KeyValuePair<string, int>("", 0);
    	foreach (System.IO.DirectoryInfo dirInfo in directoryList)
    	{
    		string versionOrigName = dirInfo.Name;
    		string versionStr = versionOrigName.Substring(1);
    		List<string> versionParts = versionStr.Split('_').ToList<string>();
    
    		int versionVal = 0;
    		int exp = 0;
    		for (int i = versionParts.Count - 1; i > -1; i--)
    		{
    			versionVal += (int.Parse(versionParts[i]) * (int)(Math.Pow(1000, exp)));
    			exp++;
    		}
    
    		if (versionVal > highestVersion.Value)
    		{
    			highestVersion = new KeyValuePair<string, int>(versionOrigName, versionVal);
    		}
    	}
    
    	return highestVersion.Key;
    }
