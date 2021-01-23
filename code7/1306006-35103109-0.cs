    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Reader> Readers { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
    public class Reader
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
