    public struct Not
    {
        public Not(bool value)
            : this()
        {
            NotValue = !value;
        }
        public bool NotValue
        {
            get;
            private set;
        }
        public static implicit operator bool(Not value)
        {
            return value.NotValue;
        }
    }
    bool trueValue = new Not(false);
