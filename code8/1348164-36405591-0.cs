    public class Set : IComparable
    {
        public DateTime time { get; set; }
        public Decimal x { get; set; }
        public Decimal y { get; set; }
        public int CompareTo(object obj)
        {
            Set other = obj as Set;
            return other == null ? 1 : x.CompareTo(other.x);
        }
    }
