        private static MyObject _instance;
        
        public static MyObject Instance 
        {
            get { return _instance; }
            set { _instance  = value; }
        } }
