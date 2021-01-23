    public IConfigurationRoot Configuration { get; set; }
    
    public class Startup
    {
        var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
    
        builder.AddEnvironmentVariables();
        Configuration = builder.Build();
    }
