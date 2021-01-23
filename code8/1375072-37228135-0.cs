    bool AreEquiv(JObject a, JObject b)
    {
    	foreach (var prop in a)
    	{
    		JToken aValue = prop.Value;
    		JToken bValue;
    		if (b.TryGetValue(prop.Key, StringComparison.OrdinalIgnoreCase, out bValue))
    		{
    			if (aValue.GetType() != bValue.GetType())
    				return false;
    		
    			if (aValue is JObject)
    			{
    				if (!AreEquiv((JObject)aValue, (JObject)bValue))
    					return false;
    			}
    			else if (!prop.Value.Equals(bValue))
    				return false;
    		}
    	}
    
    	return true;
    }
