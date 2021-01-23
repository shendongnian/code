    private static Singleton instance;
    public static Singleton Instance
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
