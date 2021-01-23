    object dictionary = info.GetValue(this, null) as IDictionary;
    if (dictionary != null)
    {
        foreach (DictionaryEntry entry in dictionary)
        {
            output[(string) entry.Key] = d[entry.Value];
        }
    }
