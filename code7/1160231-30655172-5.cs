    var newDict = new Dictionary<string, string>(); // adjust the key and value types as needed
    foreach (var kvp in dictionary1)
    {
        string value2;
        if (dictionary2.TryGetValue(kvp.Key, out value2))
        {
            newDict.Add(kvp.Value, value2);
        }
    }
