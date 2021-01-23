    public IEnumerable<ClubConfig> GetConfig(string CID, string name)
    {
        return db.ap_GetInfo(CID, name)
            .Where(x => !string.IsNullOrEmpty(x.Name))
            .Select(x => new ClubConfig
            {
                Name = x.Name.ToString(),
                Value = x.Value.ToString(),
            })
            .DefaultIfEmpty(new ClubConfig
            {
                Name = "DefaultName",
                Value = "DefaultValue"
            });
    }
