    public class MethodBaseComparer : IEqualityComparer<MethodBase>
    {
        public bool Equals(MethodBase x, MethodBase y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.MetadataToken.Equals(y.MetadataToken) &&
                   x.MethodHandle.Equals(y.MethodHandle);
        }
        public int GetHashCode(MethodBase obj)
        {
            return (obj.MetadataToken.GetHashCode() * 387) ^ obj.MethodHandle.GetHashCode();
        }
    }
