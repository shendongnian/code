    public class Blog
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public ICollection<Post> Posts {get; set;}
    }
    public class Post
    {
        public int Id {get; set;}
        public int BlogId {get; set;} // will become foreign key to Blog
        public virtual Blog Blog {get; set;}
        public string Text {get; set;
    }
    public class BlogContext : DbContext
    {
        public BlogContext() : base("DbTestBlogs") {}
        public DbSet<Blog> Blogs {get; set;}
        public DbSet<Post> Posts {get; set;}
    }
