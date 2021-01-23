    class bar
    {
        private readonly List<foo> a = new List<foo>();
        private readonly List<foo> b = new List<foo>();
        public IReadOnlyList<foo> A { get; private set; }
        public IReadOnlyList<foo> B { get; private set; }
        public bar()
        {
            A = a.AsReadOnly();
            B = b.AsReadOnly();
        }
    }
