    struct nodeParams
    {
        internal string State;
        internal string Investor;
        internal double Price;
        internal string Product;
    }
    
    internal ConcurrentDictionary<string, nodeParams> cd = new ConcurrentDictionary<string, nodeParams>();
