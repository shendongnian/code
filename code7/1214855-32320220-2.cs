    public string PropertiesJson;
    public Dictionary<string, object> Properties
    {
        get { return JsonConvert.DeserializeObject<Dictionary<string, object>>(PropertiesJson); }
        set { PropertiesJson = JsonConvert.SerializeObject(value); }
    }
