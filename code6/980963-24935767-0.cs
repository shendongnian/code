    public class EmpsSummary : IEquatable<EmpsSummary>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    
        public bool Equals(EmpsSummary other)
        {
    
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;
    
            //Check whether the products' properties are equal.
            return FirstName.Equals(other.FirstName) &&
                   LastName.Equals(other.LastName) &&
                   Phone.Equals(other.Phone);
        }
    
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public override int GetHashCode()
        {
            int hashProductFirstName  = FirstName == null ? 0 : FirstName.GetHashCode();
    
            int hashProductLastName = LastName == null ? 0 : LastName.GetHashCode();
    
            int hashProductPhone = Phone == null ? 0 : Phone.GetHashCode();
    
            //Calculate the hash code 
            return hashProductFirstName  ^ hashProductLastName  ^ hashProductPhone;
        }
    }
