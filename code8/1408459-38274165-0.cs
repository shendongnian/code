    foreach (String arrValue in arrBIOSVersion)
    {
        Console.WriteLine("BIOSVersion: {0}", arrValue);
    
        string[] split = arrValue.Split('.');
    
        string version;
        if (split.Length > 3)
            version = split[2];
    }
