    public static IConfigurationRoot Configuration;
    // You can use both IHostingEnvironment and IApplicationEnvironment at the same time.
    // Instances of them are being injected at runtime by dependency injection.
    public Startup(IHostingEnvironment hostingEnv, IApplicationEnvironment appEnv)
    {
        // Set up configuration sources.
        var builder = new ConfigurationBuilder()
            .SetBasePath(appEnv.ApplicationBasePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
        if (env.IsDevelopment())
        {
            // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            builder.AddUserSecrets();
            // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
            builder.AddApplicationInsightsSettings(developerMode: true);
        }
        builder.AddEnvironmentVariables();
        Configuration = builder.Build();
    }
