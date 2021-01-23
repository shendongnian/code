    public Dictionary<string, string> ToDictionary()
    {
        var json = JsonConvert.SerializeObject(this);
      
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    }
    
