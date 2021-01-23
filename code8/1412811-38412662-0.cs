    JObject o = new JObject
    {
        { "name1", "value1" },
        { "name2", "value2" }
    };
    
    foreach (JProperty property in o.Properties())
    {
        Console.WriteLine(property.Name + " - " + property.Value);
    }
    // name1 - value1
    // name2 - value2
    
    foreach (KeyValuePair<string, JToken> property in o)
    {
        Console.WriteLine(property.Key + " - " + property.Value);
    }
    // name1 - value1
    // name2 - value2
