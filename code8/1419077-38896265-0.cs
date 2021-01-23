    public static DataContext Generate()
    {
        var options = CreateNewContextOptions();
        var context = new DataContext(options);
        CreateRecentActivity(context);
        CreateAnnouncement(context);
        context.SaveChanges();
        return context;
    }
    private static DbContextOptions<DataContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh 
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();
        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseInMemoryDatabase()
               .UseInternalServiceProvider(serviceProvider);
        return builder.Options;
    }
