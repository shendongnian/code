    public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);         
            using (var db = new MyDbContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }
        }
