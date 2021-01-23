    string[] orderedKeys = { "Quick", "Brown", "Fox", "Jumped", "Over" };
    foreach (var key in orderedKeys)
    {
        List<object> values;
        if (dictionary.TryGetValue(key, out values))
        {
            // Here you have the key and the list of values
        }
        else
        {
            // The key was not in the dictionary.
        }
    }
