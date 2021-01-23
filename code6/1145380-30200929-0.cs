    public class MyContext : DbContext
    {
        // DbSets etc. defined here
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
            .Entities()
            .Configure(c =>
                {
                    var nonPublicProperties = c.ClrType.GetProperties(BindingFlags.NonPublic|BindingFlags.Instance);
 
                    foreach (var p in nonPublicProperties)
                    {
                        c.Property(p).HasColumnName(p.Name);
                    }
                });
          }
    }
