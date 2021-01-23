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
            if (obj == null) throw new ArgumentNullException("obj");
            if (obj.HasValue) return obj.Value.GetHashCode();
            else return obj.GetHashCode();
        }
    }
