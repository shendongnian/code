    class Part : IEquatable<Part>
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public bool Equals(Part other)
        {
    
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;
    
            //Check whether the products' properties are equal.
            return id.Equals(other.id) && name.Equals(other.name);
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public override int GetHashCode()
        {
    
            //Get hash code for the Name field if it is not null.
            int nameHash = name == null ? 0 : name.GetHashCode();
    
            int idHash = id.GetHashCode();
    
            //Calculate the hash code for the part.
            return nameHash ^ idHash;
        }
    }
