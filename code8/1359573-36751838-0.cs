    internal sealed class Configuration : DbMigrationsConfiguration<Model.Model>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
                MigrationsDirectory = @"Customer\\Migrations";
            }
    
            protected override void Seed(Model.Model context)
            {
                //  This method will be called after migrating to the latest version.
    
                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data. E.g.
    
            }
        }
