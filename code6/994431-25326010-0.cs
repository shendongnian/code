    public Version AssemblyVersion
    {
        get
        {
            return Assembly.GetEntryAssembly().GetName().Version;
        }
    }
