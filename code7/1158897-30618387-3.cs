    ReferenceData r = new ReferenceData();
    
    r.Data = new List<DataItem>();
    
    r.Data.Add(new DataItem { Item = new Dictionary<string, string>() { { "1", "2" }, { "3", "4" } } });
    
    
    
    var anon = new
    {
        data = r.Data.ToList().Select(x =>
            {
                dynamic data = new ExpandoObject();
    
                IDictionary<string, object> dictionary = (IDictionary<string, object>)data;
    
                foreach (var key in x.Item.Keys)
                    dictionary.Add(key, x.Item[key]);
    
                return dictionary;
           }
        )
    };
    
    var result = JsonConvert.SerializeObject(anon);
