    	var ret = type.GetFields().ToDictionary(x => x.Name, x => x.GetValue(null));
    
    	foreach (var nestedType in type.GetNestedTypes())
    	{
    		ret.Add(nestedType.Name, TypeToDictionary(nestedType));
    	}
    	
    	return ret;
    }
