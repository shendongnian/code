    public void ConfigureServices(IServiceCollection services)
    {
        var env = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
        if (env.IsDevelopment())
            Console.WriteLine("Development");
        else if (env.IsProduction())
            Console.WriteLine("Production");
        else if (env.IsEnvironment("MyCustomEnvironment"))
            Console.WriteLine("MyCustomEnvironment");
    }
