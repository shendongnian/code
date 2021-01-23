    List<string> keys = null;
    string rootKeyName = null;
    using (RegistryKey RootKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM", false))
    {
        if (RootKey != null)
        {
            keys = new List<string>(RootKey.GetValueNames());
            rootKeyName = RootKey.Name;
        }
    }
    if (keys != null && !string.IsNullOrEmpty(rootKeyName))
    {
        foreach (string drv in keys)
        {
            string port = Registry.GetValue(rootKeyName, drv, string.Empty) as string;
            if( port != null)
            {
                Console.WriteLine("Port: {0}, Device: {1}", port, drv);
            }
        }
    }
