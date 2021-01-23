    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person { Name = "foo" },
                new Person { Name = "bar" }
            };
            var fooPerson = people.FirstOrDefault(x => x.Name == "foo");
            // Use fooPerson
        }
    }
