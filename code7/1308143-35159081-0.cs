    IDictionary<string, string> dictionary = value as IDictionary<string, string>;
    if (dictionary != null)
    {
        ICollection<string> keys = dictionary.Keys;
        ICollection<string> values = dictionary.Values;
        // Either of those can be bound to a ListView or GridView ItemsSource
        return values;
    }
    return null;
