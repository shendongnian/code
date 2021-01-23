    public bool TryParseDictionaryItem<T>(string s, Dictionary<string, T> dictionary, out T result)
    {
       if (dictionary.TryGetValue(s, out result)) {
           return true;
       }
       return false;
