    public class MyComparator : IEqualityComparer<Size>
    {
        public bool Equals(Size x, Size y)
        {
            return x.Name == y.Name && x.Bytes == y.Bytes;
        }
        public int GetHashCode(Size obj)
        {
            return obj.Bytes;
        }
    }
