    public List<Config> getConfigSingle(string CID, string name)
    {
    var raw = db.ap_GetInfo(CID, name);
    return raw.Select(r => new Config 
                            { 
                               Name = r.Name.ToString(), 
                               Value = r.Value.ToString()
                            }).ToList();
}    
