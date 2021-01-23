      public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
      {
        ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Comment>().ToTable("Comments");
        }
      }
