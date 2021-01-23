    protected override void OnStart(string[] args)
    {
        var configProvider = new MemoryConfigurationProvider();
        configProvider.Add("server.urls", "http://localhost:5000");
        var config = new ConfigurationBuilder()
            .Add(configProvider)
            .Build();
        _application = new WebHostBuilder(config)
            .UseServer("Microsoft.AspNet.Server.Kestrel")
            .UseStartup(app =>
            {
                app.UseDefaultFiles();
                app.UseFileServer();
                // app.UseStaticFiles();
            })
            .Build()
            .Start();
    }
