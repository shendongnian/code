    class WrapperA : IWrapper
    {
        private A _a;
        public WrapperA(A a) { _a = a; }
        public Name
        {
            get { return _a.Name; }
            set { _a.Name = value; }
        }
        // other properties here
    }
