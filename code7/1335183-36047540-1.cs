    public class Configuration : DbMigrationsConfiguration<Context.MyDBContext>
        {
            private readonly bool _pendingMigrations;
    
            public Configuration()
            {
                AutomaticMigrationsEnabled = true;
    
                // Check if there are migrations pending to run, this can happen if database doesn't exists or if there was any
                //  change in the schema
                var migrator = new DbMigrator(this);
                _pendingMigrations = migrator.GetPendingMigrations().Any();
    
                // If there are pending migrations run migrator.Update() to create/update the database then run the Seed() method to populate
                //  the data if necessary
                if (_pendingMigrations)
                {
                    migrator.Update();
                    Seed(new Context.MyDBContext());
                }
            }
    
            protected override void Seed(Context.MyDBContext context)
            {
                // Microsoft comment says "This method will be called after migrating to the latest version."
                // However my testing shows that it is called every time the software starts
    
                // Run whatever you like here
    
                // Apply changes to database
                context.SaveChanges();
                base.Seed(context);
            }
        }
