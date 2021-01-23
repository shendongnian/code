    // Assume dictionary is created using reflection
    IDictionary dictionary = new Dictionary<string, object>();
    var stronglyTypedDictionary = new Dictionary<string, object> { {"hello", null} };
    foreach(var item in stronglyTypedDictionary)
    {
        dictionary.Add(item.Key, item.Value);
    }
    
