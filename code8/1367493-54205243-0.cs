    var response = client.GetMapping<object>(mapping => mapping.Index(currentIndex).AllTypes());    
    IEnumerable<Nest.TypeName> keys = response.Indices.Values.First().Mappings.Keys;
    
    foreach(var key in keys)
    {
        Console.WriteLine(key.ToString());
    }
