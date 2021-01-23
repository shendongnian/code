    public static T DeserializeAndUnwrap<T>(string json)
    {
        JObject jo = JObject.Parse(json);
        return jo.Properties().First().Value.ToObject<T>();
    }
