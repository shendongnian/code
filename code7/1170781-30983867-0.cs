    public class Demo : IEquatable<Demo>
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public bool Equals(Demo other)
        {
            if (ReferenceEquals(other, null)) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return other.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
