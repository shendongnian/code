    public class YourDataContex : DbContext()
    {    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
           modelBuilder.Entity<PostLike>()
           .HasRequired(c => c.User)
           .WithMany()
           .WillCascadeOnDelete(false);
        }
        public DbSet<User> Users { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostLike> PostLikes { set; get; }
    }
