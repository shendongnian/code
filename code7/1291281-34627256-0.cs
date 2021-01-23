    public class MyGlobalClass
    {
        private static MyGlobalClass _instance;
        private static object _myObject;
        protected MyGlobalClass()
        {
            if (HttpContext.Current.Application["MyObject"] != null)
            {
                _myObject = (object)HttpContext.Current.Application["MyObject"];
                return;
            }
            _myObject = new object();
            HttpContext.Current.Application["MyObject"] = _myObject;
        }
        public static MyGlobalClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MyGlobalClass();
            }
            return _instance;
        }
        public static object GetObject()
        {
            return _myObject;
        }
    }
