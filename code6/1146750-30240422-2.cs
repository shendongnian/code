    public T TryParseDictionaryItem<T>(string s, Dictionary<string, T> dictionary, out bool Success)
    {
       T result = default(T);
       Success = (dictionary.TryGetValue(s, out result)) 
       return result;
    }
