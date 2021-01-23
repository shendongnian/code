    public class MyMonkeyService : IMyMonkeyService
    {
        private static MyMonkeyService _instance;
        public static IMyMonkeyService Instance
        {
            get
            {
                // Gets the singleton if created, otherwise create a new instance
                return _instance != null ? _instance : (_instance = new MyMonkeyService());
            }
        }
        // Private constructor
        private MyMonkeyService()
        {
           // ...
        }
    }
