    public class Comparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.ID == y.ID; // or whatever defines your equality
        }
        public int GetHashCode(Person obj)
        {
            return obj.ID; // or whatever makes a good hash
        }
    }
