    public class MethodBaseComparer : IEqualityComparer<MethodBase>
    {
        public bool Equals(MethodBase x, MethodBase y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null))
	            return ReferenceEquals(y, null);
            return x.MetadataToken.Equals(y.MetadataToken) && x.MethodHandle.Equals(y.MethodHandle);
        }
        public int GetHashCode(MethodBase obj)
        {
            return obj.MetadataToken.GetHashCode();
        }
    }
