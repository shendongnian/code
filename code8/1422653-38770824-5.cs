    public void Configure(IApplicationBuilder app)
    {    
        // Remove call to app.UseIISPlatformHandler(); 
        // Remove call to app.UseForwardedHeaders(); 
        // Both are handled by UseIISIntegration in Main.
    }
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseIISIntegration() // Replace UseIISPlatformHandlerUrl()
            .UseStartup<Startup>()
            .Build();
        host.Run();
    }
