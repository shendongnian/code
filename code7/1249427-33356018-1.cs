    class testClassWithArray
    {
        // Collection of booleans
        public bool[] boolArray { get; private set; }
    
        // Collection of wrapped booleans
        private List<boolWrapper> _boolWrappedArray;
        public ReadOnlyCollection<boolWrapper> boolWrappedArray
        {
            get { return _boolWrappedArray.AsReadOnly(); }
        }
    
        // Filling collections with some values
        public testClassWithArray()
        {
            boolArray = new bool[3];
            _boolWrappedArray = new List<boolWrapper>();
            for (int i = 0; i < 3; i++)
            {
                _boolWrappedArray.Add(new boolWrapper(false));
            }
        }
    }
