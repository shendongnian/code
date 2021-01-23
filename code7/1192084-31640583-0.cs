    public class Country
    {
        public string Name { get; set; }
    }
    public class Language
    {
        public string Name { get; set; }
    }
    public class ProfileObject
    {
        public Person Person { get; set; }
        public IEnumerable<Node<Language>> Language { get; set; }
        public IEnumerable<Node<Country>> Country { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
