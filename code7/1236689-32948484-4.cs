    private static readonly object singletonSection = new object();
    private static Foo instance = null;
    public static Foo Instance
    {
        get
        {
            if (null == instance)
            {
                lock(singletonSection)
                {
                    if (null == instance)
                        instance = new Foo();
                } 
            }
            return instance;
        }
    }
