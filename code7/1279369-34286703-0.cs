    _data.Select(i => i.Values).Cast<Dictionary<string, string>>()
        .Where(d => d.ContainsValue("apple"))
        .SelectMany(s=>s).ToList().ForEach((item) =>
                {
                    
                    item.Key
                    item.Value...
                });
