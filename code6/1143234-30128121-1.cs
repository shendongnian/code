    var myDict = new Dictionary<string, List<double>>();
    var newKey = "newKey";
    var newValue = 0.5;
    if (myDict.ContainsKey(newKey))
    {
    	var list = myDict[newKey];
    	if (list.Count < 2)
    	{
    		// Add if not yet two entries
    		myDict[newKey].Add(newValue);
    	}
    }
    else
    {
    	myDict.Add(newKey, new List<double>() { newValue });
    }
