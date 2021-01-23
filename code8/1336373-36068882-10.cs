    public static IConfiguration GetDefault(string[] args)
    {
        // code omitted for clarity
        var configBuilder = new ConfigurationBuilder()
            .AddInMemoryCollection(defaultSettings)
            .AddJsonFile(WebHostDefaults.HostingJsonFile, optional: true)
            .AddEnvironmentVariables(prefix:
               WebHostDefaults.EnvironmentVariablesPrefix);
        
        // code omitted for clarity
        return configBuilder.Build();
    }
