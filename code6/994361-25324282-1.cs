    public class ZoneComparer : IEqualityComparer<Zone>
    {
        public bool Equals(Zone x, Zone y)
        {
            if (ReferenceEquals(x, y)) return true;
    
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
    
            return x.Equals(y);
        }
    
        public int GetHashCode(Zone product)
        {
            if (Object.ReferenceEquals(product, null)) return 0;
    
            return product.GetHashCode();
        }
    }
