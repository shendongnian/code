    public class Comment
    {
        public Guid id { get; set; }
        public string content { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("post")]
        public Guid? PostId { get; set; }
        public int numComment { get; set; }
        public virtual Post post { get; set; }
        public virtual ApplicationUser author { get; set; }
    }
    public class Post
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public virtual ICollection<ApplicationUser> author { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
    }
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=Connection")
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
