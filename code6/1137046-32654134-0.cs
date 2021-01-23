    public class MyHub : Hub
    {
        private static MyHub _instance;
        public static MyHub GetInstance()
        {
            return _instance;
        }
        public MyHub()
        {
            _instance = this;
        }
    }
