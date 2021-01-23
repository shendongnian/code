    private static DataBaseService _instance;
    // public property
    public static DataBaseService Instance
    {
        get
        {
            return _instance ?? (_instance = new DataBaseService());
        }
    }
