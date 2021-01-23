    public class Single
    {
        private static Single instance;
        private Single() { }
        static Single()
        {
            instance = new Single();
        }
        public static Single Instance
        {
            get { return instance; }
        }
    }
