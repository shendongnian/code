    public class  PersonIdComparer: IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if(object.ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.ID == y.ID;
        }
        public int GetHashCode(Person obj)
        {
            return obj == null ? int.MinValue : obj.ID;
        }
    }
