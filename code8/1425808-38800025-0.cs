    public class AppContext : DbContext
    {
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
          // ...
          modelBuilder.Entity<YourModelEntity>.Property(p => p.Birth).IsOptional();
       }
       
    }
