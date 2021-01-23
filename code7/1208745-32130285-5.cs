        // ...
        // The field itself is not needed: private value;
        // ...
        
        public void Add()
        {
            ++Value;
        }
        public int Value { get; private set; }
