    bool DictionaryContainsText(Dictionary<string, object> dictionary, string text)
    {
        string key = "word";
        if (dictionary.ContainsKey(key) && dictionary[key] != null)
        {
            return dictionary[key].Equals(text);
        }
        
        return false;
    }
