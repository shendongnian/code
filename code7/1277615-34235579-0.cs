    public class EmployeeComparer : EqualityComparer<Employee>
    {
        public override bool Equals(Employee x, Employee y)
        {
             return x.EmployeeId == y.EmployeeId
                 && x.FirstName == y.FirstName
                 && x.Age == y.Age
                 && x.LastName == y.LastName
        }
    
        //Implmentation taken from http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        public override int GetHashCode(Employee obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int) 2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 ^ obj.EmployeeId.GetHashCode();
                hash = hash * 16777619 ^ obj.FirstName.GetHashCode();
                hash = hash * 16777619 ^ obj.Age.GetHashCode();
                hash = hash * 16777619 ^ obj.LastName.GetHashCode();
                return hash;
            }
        }
    }
