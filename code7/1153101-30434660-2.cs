    public class Line
    {
        [XmlAttribute("address")]
        public string Address { get; set; }
    
        [XmlAttribute("data")]
        public string Data { get; set; }
    
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Line)obj);
        }
    
        private bool Equals(Line other)
        {
            return string.Equals(Address, other.Address) && string.Equals(Data, other.Data);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0) * 397) ^ (Data != null ? Data.GetHashCode() : 0);
            }
        }
    }
