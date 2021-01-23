    IDictionary dictionary = value as IDictionary;
    if (dictionary != null)
    {
        ICollection keys = dictionary.Keys;
        ICollection values = dictionary.Values;
        // Either of those can be bound to a ListView or GridView ItemsSource
        return values;
    }
    return null;
