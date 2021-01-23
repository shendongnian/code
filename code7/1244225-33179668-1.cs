    Dictionary<string, string> _keys = new Dictionary<string, string>();
    private void ReadInKeyFile(string keyFileName)
    {
        _keys.Clear();
        string[] lines = System.IO.File.ReadAllLines(keyFileName);
        foreach (string line in lines)
        {
            string[] keyval = line.Split('=');
            _keys.Add(keyval[0], keyval[1]);
        }
    }
    private string GetValue(string key)
    {
        string retVal = string.Empty;
        _keys.TryGetValue(key, out retVal);
        return retVal;
    }
