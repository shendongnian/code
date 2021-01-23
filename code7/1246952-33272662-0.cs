    void Main()
    {
    	var obj = JsonConvert.DeserializeObject(jsonStr) as JObject;	
    	var props = GetPropPaths(string.Empty, obj);
    	props.Dump();
    }
    
    private IEnumerable<Tuple<string, string>> GetPropPaths(string currPath, JObject obj)
    {
    	foreach(var prop in obj.Properties())
    	{
    		var propPath = string.IsNullOrWhiteSpace(currPath) ? prop.Name : currPath + "." + prop.Name;
    				
    		if (prop.Value.Type == JTokenType.Object)
    		{	
    			foreach(var subProp in GetPropPaths(propPath, prop.Value as JObject))
    				yield return subProp;
    		} else {
    			yield return new Tuple<string, string>(propPath, prop.Value.ToString());
    		}
    	}
    }
