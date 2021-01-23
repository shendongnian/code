    public class Startup
    {
        public static string ConnectionString { get; private set; }
    
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddUserSecrets();
    
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
    
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            ConnectionString = Configuration.Get<string>("Data:MongoDB:MongoServerSettings");
        }
        // ...
    }
