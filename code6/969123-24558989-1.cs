    var q =
        (from t in db.GetTable<Tenant>()
        select new {lfname = t.lname + " " + t.fname, t.tenantID});
    
    Dictionary<String, Int32> idDictionary = new Dictionary<String, Int32>();
    
    foreach(var item in q)
    {
        idDictionary.Add(item.lfname, item.tenantID);
        source.AddRange(q);
    }
    ...
    String currentSuggestion = ...
    Int32 id = idDictionary[currentSuggestion];
    dbContext.Entities.RemoveById(id);
    
