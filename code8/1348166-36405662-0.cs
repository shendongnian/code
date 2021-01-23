    public class Set : IComparable
    {
        public DateTime time { get; set; }
        public Decimal x { get; set; }
        public Decimal y { get; set; }
        public int CompareTo(object obj) 
        {
               if (obj == null) return 1;
               Set s = obj as Set;
               if (s != null) 
                   return this.time.CompareTo(s.time);
               else
                  throw new ArgumentException("Object is not a Set");
        }
    }
