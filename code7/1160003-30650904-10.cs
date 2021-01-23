    public class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
    {
        #region IEqualityComparer<T> Members
        public bool Equals(T x, T y)
        {
            return object.ReferenceEquals(x, y);
        }
        public int GetHashCode(T obj)
        {
            return (obj == null ? 0 : obj.GetHashCode());
        }
        #endregion
    }
