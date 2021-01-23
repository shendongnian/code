    public class YourDbContext : DbContext
    { 
      public DbSet<Courses> Courses { set; get; }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Courses>().HasKey(f => f.CourseID);
      }
    }
