    private static Lazy<MyClass> _instance = new Lazy<MyClass>(() => return new MyClass());
    
    public static MyClass Instance
    {
       get {
          return _instance.Value;
       }
    }
    public void MyConsumerMethod()
    {
        lock (Instance)
        {
            // this is safe usage
            Instance.SomeMethod();
        }
        // this can be unsafe operation
        Instance.SomeMethod();
    }
