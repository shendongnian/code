    private static DbContextOptions<BloggingContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh 
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();
        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseInMemoryDatabase()
               .UseInternalServiceProvider(serviceProvider);
        return builder.Options;
    }
