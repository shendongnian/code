    public class Program
    {
        public static ILoggerFactory LoggerFactory;
        public static IConfigurationRoot Configuration;
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (String.IsNullOrWhiteSpace(environment))
                throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");
            Console.WriteLine("Environment: {0}", environment);
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory, "../../../")) 
               /// It's a hack for Development. For Production Use
               /// .SetBasePath(AppContext.BaseDirectory)
               /// Include appsettings.json in project.json
               /// "publishOptions": {
               ///    "include": [
               ///      "appsettings.json"
               ///    ]
               ///  },
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true);
            
            Configuration = builder.Build();
            LoggerFactory = new LoggerFactory()
                .AddConsole(Configuration.GetSection("Logging"))
                .AddDebug();
        }
    }
