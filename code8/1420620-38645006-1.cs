    public class PersonComaparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null && y == null)
                return true;
            if ((x == null && y != null)
                || (x != null && y == null))
                return false;
            return x.Id == y.Id;
        }
        public int GetHashCode(Person obj)
        {
            if (obj == null)
                return 0;
            return obj.Id.GetHashCode();
        }
    }
