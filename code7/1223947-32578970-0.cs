     public class className : DbContext
     {
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
          modelBuilder.Configurations.Add(new AClassConfiguration());
      }
     }
