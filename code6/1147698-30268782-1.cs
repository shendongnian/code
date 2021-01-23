    public string GetJsonNetSerializedString()
    {
        var keys = ConfigurationManager.AppSettings.AllKeys
            .Select(key => new 
            { 
                Key = key, 
                Value = ConfigurationManager.AppSettings[key] 
            });
        string json = JsonConvert.SerializeObject(keys, Formatting.Indented);
        return json;
    }
