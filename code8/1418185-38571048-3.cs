    class TestClass
    {
        private readonly object _lockObject;
        private readonly static Lazy<TestClass> _instance = new Lazy<TestClass>(x=> new TestClass());
    
        private TestClass()
        {
            _lockObject = new object();
        }
    
        public static TestClass Instance
        {
            get { return _instance.Value; }
        }
        ...
    }
