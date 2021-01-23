    public class NullableEntityComparer<TType> : IEqualityComparer<TType?> 
            where TType : struct
    {
        public bool Equals(TType? x, TType? y)
        {
            if(!x.HasValue && ! y.HasValue) return true;
            if(x.HasValue && y.HasValue) return x.Value.Equals(y.Value);
            return false;
        }
    
        public int GetHashCode(TType? obj)
        {
            return obj.GetHashCode();
        }
    }
