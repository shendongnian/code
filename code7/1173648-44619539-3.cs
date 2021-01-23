    public class DatabaseClass : DbContext 
    {
	    //...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("my connection string");
        }
    }
