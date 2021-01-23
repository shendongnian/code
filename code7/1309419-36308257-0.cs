    public class Person : Suple<string, string>
    {
        public Person(string firstName, string lastName)
            : base(firstName, lastName, SupleHash.Cached)
        {
        }
    
        public string FirstName => Item1;
        public string LastName => Item2;
    }
