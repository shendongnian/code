    class bar
    {
        private readonly List<foo> a = new List<foo>();
        private readonly List<foo> b = new List<foo>();
    
        public IReadOnlyList<foo> A { get {return a.AsReadOnly();}}
        public IReadOnlyList<foo> B { get {return b.AsReadOnly();}}
    
    }
