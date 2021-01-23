    using Newtonsoft.Json.Linq;
    ...
    String jsonStr = "{\"name1\": \"example\",\"name2\": \"example2\",\"name3\": \"example3\",\"name4\": \"example4\"}";
    JObject obj=JObject.Parse(jsonStr);
    foreach (JProperty prop in obj.Properties())
    {
        string key = prop.Name;
        var value = prop.Value.ToString();
    }
