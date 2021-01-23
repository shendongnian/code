    static Dictionary<string,object> ToDictionary(IDictionary dic)
    {
        var d = dic.Cast<DictionaryEntry> ();
        return d.ToDictionary ((t) => t.Key.ToString (), (t) => t.Value);
    }
