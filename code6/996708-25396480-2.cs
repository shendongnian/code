    public class Location : IEquatable<Location>
    {
        public int Id { get; set; }
        public bool Equals(Location other)
        {
            //Check whether the compared object is null.  
            if (object.ReferenceEquals(other, null)) return false;
            //Check whether the compared object references the same data.  
            if (object.ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
