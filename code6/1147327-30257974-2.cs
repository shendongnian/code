    public IEnumerable<ClubConfig> getConfigOrDefault(string CID, string name)
    {
        var result = getConfig(CID, name).ToList();
        if (result.Any())
            return result;
        else
            return new[] {new Config {Name = "DefaultName", Value = "DefaultValue"}};
    }
