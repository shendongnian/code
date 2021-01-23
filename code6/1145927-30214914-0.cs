     public IEnumerable<Config> getConfigSingle(string CID, string name)
            {
                var raw = db.ap_GetInfo(CID, name);
    
                foreach (var item in raw.ToList())
                {
                    yield return new Config
                    {
                        Name = item.Name.ToString(),
                        Value = item.Value.ToString(),
                    };
                }       
            }
