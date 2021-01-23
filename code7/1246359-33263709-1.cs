    public class Context : DbContext
        {
            public DbSet<DataFileParent> DataFileParents { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<DataFileEditor>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("DataFileEditor");
                });
    
                modelBuilder.Entity<DataFileStore>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("DataFileStore");
                });
            }
        }
