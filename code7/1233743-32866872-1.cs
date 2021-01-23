    internal sealed class Configuration : DbMigrationsConfiguration<MigratingDatabase.SchoolContext>
    {
            public Configuration()
            {
                AutomaticMigrationsEnabled = true;
            }
    
            protected override void Seed(MigratingDatabase.SchoolContext context)
            {
    		
            }
    }
