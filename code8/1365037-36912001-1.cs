    public class StarSign : IComparable<StarSign>
    {
        public StarSign(string name, DateTime start, DateTime end)
        {
            if (start >= end) throw new ArgumentException("Start must be < end");
            this.Name = name;
            this.Start = start;
            this.End = end;
        }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CompareTo(StarSign other)
        {
            if (other == null) return 1;
            return Start.CompareTo(other.Start);
        }
        public bool IsStarSign(DateTime dt)
        {
            DateTime normalizedDate = new DateTime(this.Start.Year, dt.Month, dt.Day);
            return normalizedDate >= Start && normalizedDate <= End;
        }
    }
