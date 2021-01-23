    using Newtonsoft.Json;
    private Action HandleBadJson(string badJson)
    {
    	Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(badJson);
    	Action act = new Action();
    	List<string> propertyNames = act.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Select(p => p.Name).ToList();
    	string currentProperty = "";
    	foreach (var keyValPair in dictionary)
    	{
    		if (propertyNames.Contains(keyValPair.Key))
    		{
    			currentProperty = keyValPair.Key;
    			act.GetType().GetProperty(currentProperty).SetValue(act, keyValPair.Value);
    			continue;
    		}
    		else
    		{
    			var currentValue = act.GetType().GetProperty(currentProperty).GetValue(act, null);
    			string value = currentValue + "," + keyValPair.Key;
    			value = value.Trim(',');
    			act.GetType().GetProperty(currentProperty).SetValue(act, value);
    		}
    	}
    	return act;
    }
