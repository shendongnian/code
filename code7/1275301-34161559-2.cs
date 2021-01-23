    public class MyEq : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return (x % 2) == (y % 2);
        }
        public int GetHashCode(int obj)
        {
            return (obj % 2).GetHashCode();
        }
    }
