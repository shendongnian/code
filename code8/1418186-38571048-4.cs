    class TestClass
    {
        private readonly object _lockObject;
        private static readonly object _singletonLock = new Object();
        private static TestClass _instance;
    
        private TestClass()
        {
            _lockObject = new object();
        }
    
        public static TestClass Instance
        {
            get 
            { 
                if(_instance == null)
                {
                    lock(_singletonLock)
                    {
                        if(_instance == null)
                        {
                            _instance = new TestClass ();
                        }
                    }
                }
                return _instance; 
            }
        }
        ...
    }
