    [DirectoryProperty("ProxyAddresses")]
    public string[] ProxyAddresses
    {
        get
        {
            object[] proxysRaw = ExtensionGet("ProxyAddresses");
            string[] proxys = new string[proxysRaw.Length];
    
            for (int x = 0; x < proxysRaw.Length; x++)
            {
                proxys[x] = (string)proxysRaw[x];
            }
    
            return proxys;
        }
        set
        {
            ExtensionSet("ProxyAddresses", value);
        }
    }
