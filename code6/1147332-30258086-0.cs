    public IEnumerable<ClubConfig> getConfig(string CID, string name) 
    {
        var raw = db.ap_GetInfo(CID, name);
        return raw.Where(x => !string.IsNullOrEmpty(x.Name))
           .Select(item => new ClubConfig
            {
                Name = item.Name.ToString(),                        
                Value = item.Value.ToString(),
            })
           .DefaultIfEmpty(new ClubConfig { Name = "n", Value="v" });
    }
