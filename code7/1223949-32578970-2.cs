     public class className : DbContext
     {
         public DbSet<AClass> AClasses { get; set; }
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Configurations.Add(new AClassConfiguration());
         }
     }
