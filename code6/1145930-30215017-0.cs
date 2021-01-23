    public Config getConfigSingle(string CID, string name)
    {
        var raw = db.ap_GetInfo(CID, name);
    
        foreach (var item in raw.ToList())
        {
            return new Config
            {
                Name = item.Name.ToString(),
                Value = item.Value.ToString(),
            };
        }  
        return null;
    }
