    public class StaticVals
    {
        private static StaticVals _instance;
        public static StaticVals Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StaticVals();
                return _instance;
            }
        }
        public Dictionary<string, string> StaticDictionary;
    }
