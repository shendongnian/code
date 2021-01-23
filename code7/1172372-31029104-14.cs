    public class ArrayComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            return ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
        }
        public int GetHashCode(T[] obj)
        {
            return obj.Select(x => x.GetHashCode()).Aggregate(0, (a, b) => a + b);
        }
    }
    public class ListOfArrayComparer<T> : IEqualityComparer<List<T[]>>
    {
        public bool Equals(List<T[]> x, List<T[]> y)
        {
            return ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y, new ArrayComparer<T>()));
        }
        public int GetHashCode(List<T[]> obj)
        {
            return obj.Select(x => x.GetHashCode()).Aggregate(0, (a, b) => a + b);
        }
    }
