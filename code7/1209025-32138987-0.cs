    foreach (var pair in firstStrings)
    {
    	foreach (var pair2 in secondStrings)
    	{
    		if (secondStrings.ContainsKey(pair.Key))
    		{
    			LogMessage(
    				pair.Value + " <----------> " + pair2.Value + " On Line " + (int)(pair.Key.Item1 + 1));
    			
    			break;
    		}
    		else if (!(secondStrings.ContainsKey(pair.Key)))
    		{
    			LogMessage(
    				pair.Value + "Missing data " + " on line " + (int)(pair.Key.Item1 + 1) + " in file " + " " +
    				Path.GetFileName(pathTwo));
    			
    			break;
    		}
    		else if (!(firstStrings.ContainsKey(pair2.Key)))
    		{
    			LogMessage(
    				pair2.Value + "Missing data " + " on line " + (int)(pair2.Key.Item1 + 1) + " in file " + " " +
    				Path.GetFileName(pathOne));
    			
    			break;
    		}
    	}
    }
