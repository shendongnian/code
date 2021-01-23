       public class Guest : IComparable<Guest>
        {
            public bool f { get; set; }
            public bool g { get; set; }
            public bool s { get; set; }
            public string name { get; set; }
            public int CompareTo(Guest other)
            {
                int results = 0;
                int thisRank = (this.f ? 1 : 0) + (this.g ? 2 : 0) + (this.s ? 4 : 0);
                int otherRank = (other.f ? 1 : 0) + (other.g ? 2 : 0) + (other.s ? 4 : 0);
                if (thisRank == otherRank)
                {
                    results = this.name.CompareTo(other.name);
                }
                else
                {
                    results = thisRank.CompareTo(otherRank);
                }
                return results;
            }
        }
