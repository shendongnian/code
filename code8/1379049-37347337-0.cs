    public static object FilterObject(Person input, string[] whitelist)
    {
    	var obj = new Dictionary<string, object>();
    
    	foreach (string propName in whitelist)
    	{
    		var prop = input.GetType().GetProperty(propName);
    
    		if(prop != null)
    		{
    			obj.Add(propName, prop.GetValue(input, null));
    		}
    	}               
    
    	return obj;
    }
