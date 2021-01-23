    public class Key : IComparable
    {
        public int Type {get; set; }
        public DateTime Time { get; set; }
        public int Sequence { get; set; }
        int IComparable.CompareTo(object obj)
        {
            Key otherKey = obj as Key;
            if (otherKey == null) throw new ArgumentException("Object is not a Key!");
            if (Type > otherKey.Type)
                return 1;
           return -1;
        }
    }
