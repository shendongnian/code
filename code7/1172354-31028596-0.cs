    JToken token = JToken.Parse(json);
    
    if (token.Type == JTokenType.Object)
    {
        Dictionary<string, object> d = token.ToObject<Dictionary<string, object>>();
    }
    else if (token.Type == JTokenType.Array)
    {
        List<object> list = token.ToObject<List<object>>();
    }
