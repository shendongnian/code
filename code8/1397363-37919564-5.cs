    public Dictionary<string, string> ToDictionary()
    {
        var json = JsonConvert.SerializeObject(this);
        
        var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(json, serializerSettings);
    }    
