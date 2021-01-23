    public class BloggingContext : DbContext
        {
    
        public BloggingContext ()
                : base("ConnectionString")
            {}
    
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
