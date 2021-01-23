    private class ValueWrapper
    {
        private readonly OtherClass _wrapped;
        public ValueWrapper(OtherClass wrapped)
        {
            _wrapped = wrapped;
        }
        public override bool Equals(object obj)
        {
            // Compare the wrapped objects for equality.
            // This needs some beefing up for null checks, type checks, etc.
            return _wrapped.Equals(obj._wrapped);
        }
        public override string ToString()
        {
            return "whatever you like";
        }
    }
