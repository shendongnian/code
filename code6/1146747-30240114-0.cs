    public T? ParseStructDictionaryItem<T>(string s, Dictionary<string, T> dictionary) where T : struct
    {
        T result;
        if (dictionary.TryGetValue(s, out result))
            return result;
        return null;
    }
    
    public T ParseReferenceDictionaryItem<T>(string s, Dictionary<string, T> dictionary) where T : class
    {
        T result;
        if (dictionary.TryGetValue(s, out result))
            return result;
        return default(T);
    }
