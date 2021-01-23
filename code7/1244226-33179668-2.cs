    private void SaveKeysToFile(string keyFileName)
    {
        StringBuilder sb = new StringBuilder();
        _keys.ToList().ForEach(kvp => 
           sb.AppendLine(string.Format("{0}={1}", kvp.Key, kvp.Value)));
        System.IO.File.WriteAllText(keyFileName, sb.ToString());
    }
    private void AddValue(string key, string value)
    {
        _keys[key] = value;
    }
