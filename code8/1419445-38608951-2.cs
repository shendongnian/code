    var results = new List<Dictionary<string, object>>();
    
    while (reader.Read())
    {
        results.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
    }
    return results;
