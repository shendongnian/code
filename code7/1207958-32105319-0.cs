     public static class InitializeAndSeed
            {
                public static void InitializeContext()
                {
                    Database.SetInitializer(new MigrateDatabaseToLatestVersion<YourDbContext 
                                            ,YourDbContextMigrations>());
        
                    using (var db = new YourDbContext())
                    {
                        db.Database.Initialize(false);
                    }
                }
        
        
            }
        
        public class YourDbContextMigrations : DbMigrationsConfiguration<YourDbContext>
            {
                
        
                public YourDbContextMigrations ()
                {
                    AutomaticMigrationsEnabled = true;
                    AutomaticMigrationDataLossAllowed = true;   
                }
    
              //Your seeding and your migrations
             }
