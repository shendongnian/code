    public class ObjectReferenceEqualityComparer<T> : IEqualityComparer<T>, IEqualityComparer
        where T : class
    {
        private static ObjectReferenceEqualityComparer<T> _defaultComparer;
        public static ObjectReferenceEqualityComparer<T> Default
        {
            get { return _defaultComparer ?? (_defaultComparer = new ObjectReferenceEqualityComparer<T>()); }
        }
        public bool Equals(T x, T y)
        {
            return object.ReferenceEquals(x, y);
        }
        public int GetHashCode(T obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
        bool IEqualityComparer.Equals(object x, object y)
        {
            return this.Equals((T)x, (T)y);
        }
        int IEqualityComparer.GetHashCode(object obj)
        {
            return this.GetHashCode((T)obj);
        }
    }
