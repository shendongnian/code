    public class AbsoluteEqual : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return (x < 0 ? -x : x) == (y < 0 ? -y : y);
        }
    
        public int GetHashCode(int obj)
        {
            return obj < 0 ? (-obj).GetHashCode() : obj.GetHashCode();
        }
    }
