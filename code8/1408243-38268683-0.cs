    public static int AtWord(this string strBuffer, int index)
    { 
    	int foundAt = -1;
    	
    	var splits = Regex.Split(strBuffer.Substring(0, index), @"(\s+)");
    	
    	if (splits.Any())
    	   foundAt = splits.Count() - 1;
    	
    	return foundAt;
    }
