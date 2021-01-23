    private static NSMutableDictionary ConvertToNativeDictionary(Dictionary<string, object> dict)
    {
    	NSMutableDictionary newDictionary = new NSMutableDictionary();
    
    	try
    	{
    		foreach (string k in dict.Keys)
    		{
    			var value = dict[k];
    
    			try
    			{
    				if (value is string)
    					newDictionary.Add((NSString)k, new NSString((string)value));
    				else if (value is int)
    					newDictionary.Add((NSString)k, new NSNumber((int)value));
    				else if (value is float)
    					newDictionary.Add((NSString)k, new NSNumber((float)value));
    				else if (value is nfloat)
    					newDictionary.Add((NSString)k, new NSNumber((nfloat)value));
    				else if (value is double)
    					newDictionary.Add((NSString)k, new NSNumber((double)value));
    				else if (value is bool)
    					newDictionary.Add((NSString)k, new NSNumber((bool)value));
    				else if (value is DateTime)
    					newDictionary.Add((NSString)k, ((DateTime)value).DateTimeToNSDate());
    				else
    					newDictionary.Add((NSString)k, new NSString(value.ToString()));
    			}
    			catch (Exception Ex)
    			{
    				if (value != null)
    					Ex.Data.Add("value", value);
    
    				Logger.LogException(Ex);
    				continue;
    			}
    		}
    	}
    	catch (Exception Ex)
    	{
    		Logger.LogException(Ex);
    	}
    	return newDictionary;
    }
