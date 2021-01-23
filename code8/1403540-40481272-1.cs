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
            var services = new ServiceCollection();
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            if (environment == "Development")
            {
                builder
                    .AddJsonFile(
                        Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{environment}.json"),
                        optional: true
                    );
            }
            else
            {
                builder
                    .AddJsonFile($"appsettings.{environment}.json", optional: false);
            }
            
            Configuration = builder.Build();
            LoggerFactory = new LoggerFactory()
                .AddConsole(Configuration.GetSection("Logging"))
                .AddDebug();
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<FmDataContext>(o => o.UseNpgsql(connectionString), ServiceLifetime.Transient);
            services.AddTransient<IPackageFileService, PackageFileServiceImpl>();
            var serviceProvider = services.BuildServiceProvider();
            var packageFileService = serviceProvider.GetRequiredService<IPackageFileService>();
            ............
        }
    }
