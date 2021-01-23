    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if(x == null && y == null) return true;
            if(x == null || y == null) return false;
            return x.SID == y.SID;
        }
        public int GetHashCode(Person obj)
        {
            return obj.SID;
        }
    }
