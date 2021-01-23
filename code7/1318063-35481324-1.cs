    public class Attribute : IComparable<Attribute>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CompareTo (Attribute other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
                return Value.CompareTo(other.Value);
            return result;
        }
    }
