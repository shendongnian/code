    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
