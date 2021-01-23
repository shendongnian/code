    public class NullsAreLast : IComparer<int?>
    {
        public int Compare (int? x, int? y)
        {
            if(!y.HasValue)
            {
                if (!x.HasValue) return 0;
                return -1;
            }
            if(!x.HasValue) return 1;
            return x.Value.CompareTo(y.Value);
        }
    }
