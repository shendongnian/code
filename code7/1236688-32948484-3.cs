    private static Foo instance = null;
    public static Foo Instance
    {
        get
        {
            if (null == instance)
                instance = new Foo();
            return instance;
        }
    }
