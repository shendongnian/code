    foreach (var kvp in paramsList)
    {
        string typeName;
        if (!paramsDictionary.TryGetValue(kvp.Key, out typeName))
        {
            // error: key isn't in parameters list
        }
        // Get the type of the object in the dictionary
        Type objectType = kvp.Value.GetType();
        if (typeName != objectType.Name)
        {
            // error: type names don't match
        }
    }
