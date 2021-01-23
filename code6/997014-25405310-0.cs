    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var j = JObject.Load(reader);
    
        if (j["Type"].ToString() == "a")
            return new AType(int.Parse(j["Height"].ToString()));
    
        return new BType(j["Name"].ToString());
    }
 
