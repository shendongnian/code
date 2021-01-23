    var dictionary = item as IDictionary;
    if (dictionary != null)
    {
        var keyList = dictionary.Select(x => x.Key.ToString()).ToArray<string>();
    }
    
