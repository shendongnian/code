    class Environment
    {
        private static Environment _instance;
        public static Environment Instance
        {
            get
            {
                 if (_instance == null)
                 {
                       _instance = new Environment();
                 }
                 return _instance;
            }
        }
        
        private Environment(){}
    
        private Combination[][] combinations;
        private string[] typenames;
        private getString[] tostrings;
    
        public Environment() { ... } //adds one 'Null' type at index 0 by default
        public void AddType(string name, getString tostring, Combination[] combos) { ... }
    
        public Value Combine(Value A, Value B)
        {
            return combinations[A.index][B.index](A, B);
        }
        public string getStringValue(Value A)
        {
            return tostrings[A.index](A);
        }
        public string getTypeString(Value A)
        {
            return typenames[A.index];
        }
    }
