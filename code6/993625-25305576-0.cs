    public struct InputEntry
    {
        public DateTime Date { get; set; }
        public string Entry { get; set; }
        public bool Equals(InputEntry other)
        {
            return Date.Equals(other.Date) && string.Equals(Entry, other.Entry);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is InputEntry && Equals((InputEntry) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ( Date.GetHashCode()*397) 
                       ^ (Entry != null ? Entry.GetHashCode() 
                                        : 0);
            }
        }
        public static bool operator ==(InputEntry left, InputEntry right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(InputEntry left, InputEntry right)
        {
            return !left.Equals(right);
        }
        private sealed class EntryDateEqualityComparer 
                                        : IEqualityComparer<InputEntry>
        {
            public bool Equals(InputEntry x, InputEntry y)
            {
                return string.Equals(x.Entry, y.Entry) && x.Date.Equals(y.Date);
            }
            public int GetHashCode(InputEntry obj)
            {
                unchecked
                {
                    return ( (obj.Entry != null ? obj.Entry.GetHashCode() : 0)*397) 
                           ^ obj.Date.GetHashCode();
                }
            }
        }
        private static readonly IEqualityComparer<InputEntry> 
                      EntryDateComparerInstance = new EntryDateEqualityComparer();
        public static IEqualityComparer<InputEntry> EntryDateComparer
        {
            get { return EntryDateComparerInstance; }
        }
    }
