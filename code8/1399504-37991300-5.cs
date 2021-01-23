    private MyClass()
    {
    }
    private static MyClass _Singleton;
    public static MyClass Singleton
    {
        get
        {
            if(_Singleton==null) _Singleton = new MyClass();
            return _Singleton
        }
    }
