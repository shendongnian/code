    public partial class MyClass : IMyInterface
    {
        private static IMyInterface _instance;
        public static IMyInterface Instance
        { 
            get 
            {
                if (_instance == null) _instance = new MyClass();
                return _instance;
            }
        }
        public void MyMethod(object obj)
        {
           //Method code....
        }
    }
