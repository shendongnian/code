    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
                    .UseIISIntegration()
                    .UseKestrel()
                    .UseContentRoot(@"Path\To\Content\Root")
                    .UseStartup<Startup>()
                    .Build();
    
        if (Debugger.IsAttached || args.Contains("--debug"))
        {
            host.Run();
        }
        else
        {
            host.RunAsService();
        }
    }
