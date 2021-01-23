    public class ProfileObject
    {
        public Person Person { get; set; }
        public IEnumerable<Node<Language>> Language { get; set; }
        public IEnumerable<Node<Country>> Country { get; set; }
    }
