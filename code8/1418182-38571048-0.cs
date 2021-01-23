    class TestClass
    {
        private readonly object _lockObject;
        private readonly static Lazy<TestClass> _instance;
    
        private TestClass()
        {
            _lockObject = new object();
            _instance = new Lazy<TestClass>(x=> new TestClass());
        }
    
        public static TestClass Instance
        {
            get { return _instance.Value; }
        }
        ...
    }
