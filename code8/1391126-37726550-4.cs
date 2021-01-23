    public static Settings Instance { get; private set; }
    static Settings()
    {
        Instance = new Settings();
    }
