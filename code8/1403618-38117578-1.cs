    public static string SortAndConvertToString(Hashtable ht)
    {
        var keysOrderedByValue = ht.Cast<DictionaryEntry>()
            .OrderBy(x => x.Value)
            .Select(x => x.Key);
        return string.Join(";", keysOrderedByValue);
    }
