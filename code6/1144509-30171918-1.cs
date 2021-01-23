    public class Person
    {
        public List<Person> Team { get; set; }
        public string Status { get; set; }
        public IEnumerable<Person> Flatten()
        {
            yield return this;
            foreach (var person in Team)
                foreach (var child in person.Flatten())
                    yield return child;
        } 
    }
