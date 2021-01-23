    public class Märk : IEquatable<Märk>, IComparable<Märk>
        {
            public int Id { get; set; }
    
            public string Value { get; set; }
    
            public override string ToString()
            {
                return "ID: " + Id + "   Value: " + Value;
            }
    
            public int Sort(string value1, string value2)
            {
                return value1.CompareTo(value2);
            }
    
            public int CompareTo(Märk compareMärk)
            {
                if (compareMärk == null)
                {
                    return 1;
                }
                else
                {
                    return Id.CompareTo(compareMärk.Id);
                }
            }
    
            public override int GetHashCode()
            {
                return Id;
            }
    
            public bool Equals(Märk other)
            {
                if (other == null) return false;
                return (this.Id.Equals(other.Id));
            }
    
            //...Add somme other codes
        }
