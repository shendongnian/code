    public IEnumerable<ClubConfig> getConfig(string CID, string name)
    {
        var raw = db.ap_GetInfo(CID, name);
        if (!raw.Any()) return new[] {
                ClubConfig 
                {
                    Name = "defaultName", 
                    Value = "defaultValue" 
                }};
        foreach (var item in raw.Where(x => !string.IsNullOrEmpty(x.Name))                       
        {
            
            yield return new ClubConfig
            {
                Name = item.Name.ToString(),                        
                Value = item.Value.ToString(),
            };        
        }        
    }
