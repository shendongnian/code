    public IEnumerable<Config> GetConfig(string CID, string name)
    {
        return db.ap_GetInfo(CID, name)
            .Where(x => !string.IsNullOrEmpty(x.Name))
            .Select(x => new Config
            {
                Name = x.Name.ToString(),
                Value = x.Value.ToString(),
            })
            .DefaultIfEmpty(new Config
            {
                Name = "DefaultName",
                Value = "DefaultValue"
            });
    }
