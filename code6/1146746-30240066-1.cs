    public T? ParseDictionaryItemValueType<T>(string s, Dictionary<string, T> dictionary)
     where T : struct
    {
        T result;
        if (dictionary.TryGetValue(s, out result))
            return result;
        return null;
    }
    public T ParseDictionaryItemReferenceType<T>(string s, Dictionary<string, T> dictionary)
     where T : class
    {
        T result;
        dictionary.TryGetValue(s, out result);
        return result;
    }
