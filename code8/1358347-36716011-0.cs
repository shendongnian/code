    public class YourDbContext : DbContext 
        {
                
            public YourDbContext (): base("yourConnectionString") 
            {
                Database.SetInitializer<YourDbContext>(new CreateDatabaseIfNotExists<YourDbContext>());
            }  
        }
