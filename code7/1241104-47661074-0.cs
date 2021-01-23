    object jValue = prop.GetValue(value);
    if (prop.PropertyType.IsArray)
    {
    	if(jValue != null)
    		//https://stackoverflow.com/a/20769644/249895
    		lastLevel[nesting[i]] = JArray.FromObject(jValue);
    }
    else
    {
    	if (prop.PropertyType.IsClass && prop.PropertyType != typeof(System.String))
    	{
    		if (jValue != null)
    			lastLevel[nesting[i]] = JValue.FromObject(jValue);
    	}
    	else
    	{
    		lastLevel[nesting[i]] = new JValue(jValue);
    	}                               
    }
