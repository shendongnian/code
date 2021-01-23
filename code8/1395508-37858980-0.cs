    var query = collection.AsQueryable();
    //Non-meta properties
    query = query.Where(a => a.SomeNonMetaProperty == "Something");
    //And now meta properties
    foreach(var keyAndValue in someDictionary)
    {
      query = query.Where(m => 
        m.Name == keyAndValue.Key
        && m.Value == keyAndValue.Value;
    }
   
