    public class MethodInfoComparer<T> : IEqualityComparer<T>
        where T : MethodBase
    {
        public bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.MetadataToken.Equals(y.MetadataToken) && x.MethodHandle.Equals(y.MethodHandle);
        }
        public int GetHashCode(T obj)
        {
            return obj.MetadataToken.GetHashCode();
        }
    }
