    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if(x == null && y == null) return true;
            int xid = x.Role == "Manager" ? x.ID : x.SID;
            int yid = y.Role == "Manager" ? y.ID : y.SID;
            return xid == yid;
        }
        public int GetHashCode(Person obj)
        {
            return obj.Role == "Manager" ? obj.ID : obj.SID;
        }
    }
