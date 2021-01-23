    public class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            if (ReferenceEquals(x, y))
                return true;
    
            if (x == null || y == null)
                return false;
    
            if (x.Length != y.Length)
                return false;
    
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < x.Length; i++)
            {
                if (!comparer.Equals(x[i], y[i])) return false;
            }
            return true;
        }
    
        public int GetHashCode(T[] obj)
        {
            int hc = obj.Length;
            for (int i = 0; i < obj.Length; ++i)
            {
                hc = unchecked(hc * 314159 + obj[i].GetHashCode());
            }
            return hc;
        }
    }
