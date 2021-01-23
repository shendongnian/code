    public class Ordered2Tuple<T> : Tuple<T, T> where T : IComparable
    {
        public Ordered2Tuple(T a, T b)
            : this(a, b, a.CompareTo(b))
        { }
        private Ordered2Tuple(T a, T b, int cmp)
            : base(cmp < 0 ? a : b, cmp < 0 ? b : a)
        { }
    }
