    public class MyDbContext : DbContext {
       protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //Tell EF not to include these in DB. Ignore these please
            // Anthing that EF picks and generates a table for that shoudl not be persisted
           // modelBuilder.Ignore<EFpleaseIgnoreMe>();
            modelBuilder.Ignore<YourType>();
        }
       }
