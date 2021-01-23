    using Newtonsoft.Json;
    private Action HandleBadJson(string badJson)
    {
    	Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(badJson);
    	Action act = new Action();
    	string currentProperty = "";
    	foreach (var keyValPair in dictionary)
    	{
    		if (!string.IsNullOrEmpty(keyValPair.Value))
    		{
    			currentProperty = keyValPair.Key;
    			act.GetType().GetProperty(currentProperty).SetValue(act, keyValPair.Value);
    			continue;
    		}
    		else
    		{
    			var currentValue = act.GetType().GetProperty(currentProperty).GetValue(act, null);
    			string value = currentValue + "," + keyValPair.Key;
    			act.GetType().GetProperty(currentProperty).SetValue(act, value);
    		}
    	}
    	return act;
    }
