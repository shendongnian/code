    private const string _kconnected = "connected";
    public List<string> receiveClientList()
    {
        List<string> val = new List<string>();
        string name = Convert.ToString(streamReader.ReadLine());
        // Need to check the *end* of the string for "connected" text,
        // not the beginning.
        if (name.EndsWith(_kconnected))
        {
            name = name.Substring(0, name.Length - _kconnected.Length);
            val.Add(name);
        }
        return val;
    }
