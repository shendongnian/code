    class Firm : IComparable<Firm>, IComparable
    {
        string acctNo;
        string name;
        string addy1;
        string city;
        bool active;
        
        int completeness
        {
            get
            {
                return accNo.Length + name.Length + addy1.Length + city.Length;
            }
        }
        
        public int CompareTo(Firm other)
        {
            var c = name.CompareTo(other.name);
            if (c != 0)
                return c;
            c = active.CompareTo(other.active);
            if (c != 0)
                return c;
            return completeness.CompareTo(other.completeness);
        }
        public int CompareTo(object other)
        {
            return CompareTo((Firm)other);
        }
        
        public static IEnumerable<Firm> sortFirms(IEnumerable<Firm> firms)
        {
            return firms.GroupBy(f => f.name).Select(g => g.OrderByDescending().First());
        }
    }
