    public class Person
    {
        public string Name { get; set; }
    }
    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name.Equals(x.Name);
        }
        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }
    }
