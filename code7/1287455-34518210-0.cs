    public class MySingletonClass
    {
        private static MySingletonClass _instance;        
        /// <summary>
        /// Get the singleton instance.
        /// </summary>
        public static MySingletonClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MySingletonClass();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Property to be shared across application.
        /// </summary>
        public string MySharedProperty { get; set; }
        // Private default constructor
        private MySingletonClass() { }
    }
