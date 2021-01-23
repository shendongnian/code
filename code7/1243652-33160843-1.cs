    // General-purpose equality comparer implementation for convenience.
    // Rather than declaring a new class for each time you want an
    // IEqualityComparer<T>, just pass this class appropriate delegates
    // to define the actual implementation desired.
    class GeneralEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _getHashCode;
        public GeneralEqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            _equals = equals;
            _getHashCode = getHashCode;
        }
        public bool Equals(T t1, T t2)
        {
            return _equals(t1, t2);
        }
        public int GetHashCode(T t)
        {
            return _getHashCode(t);
        }
    }
