    // prepare return object
    returnResult.Value = new Dictionary<string, string>();
    
    // discover data type
    Newtonsoft.Json.Linq.JTokenType parseAs = values[prop].Type;
    
    // parse the data and push it as string into the dictionary
    if (parseAs == Newtonsoft.Json.Linq.JTokenType.String)
    {
    	returnResult.Value.Add(prop, (string)values[prop].Value);
    }                        
    else if (parseAs == Newtonsoft.Json.Linq.JTokenType.Integer)
    {
    	returnResult.Value.Add(prop, ((Int16)values[prop].Value).ToString());
    }
    else if (parseAs == Newtonsoft.Json.Linq.JTokenType.Boolean)
    {
    	returnResult.Value.Add(prop, ((Boolean)values[prop].Value).ToString());
    }
    else if (parseAs == Newtonsoft.Json.Linq.JTokenType.Array)
    {
    	// in case of an array, when value is received by the corresponding method
    	// the way of deserializing and parsing will be decided then
    	returnResult.Value.Add(prop, values[prop].ToString());
    }
