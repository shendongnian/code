    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public ICollection<Post> Posts {get; set;}
    }
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
     }
