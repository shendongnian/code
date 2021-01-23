    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }
    
    public static IWebHost BuildWebHost(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration((context, builder) => builder.SetBasePath(context.HostingEnvironment.ContentRootPath)
         .AddJsonFile("appsettings.json").Build())
         .UseStartup<Startup>().Build();
