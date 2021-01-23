    struct QuoteUpdate
    {
        public string S { get; private set; }
        public double B { get; private set; }
        public double A { get; private set; }
        public QuoteUpdate(string s, double b, double a) : this()
        {
            S = s;
            B = b;
            A = a;
        }
    }
