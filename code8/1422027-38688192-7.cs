    public class MyDbContext:DbContext
    {
        ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfig());            
        }
    }
