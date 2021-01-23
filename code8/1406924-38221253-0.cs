    public class Person
    {
        public string Name { get; set; }
        public Person Parent { get; set; }
        public ICollection<Person> Children { get; set; }
    } 
