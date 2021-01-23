    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    
            if (args.Contains("--windows-service"))
            {
                host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot("<directory-containing-wwwroot>")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://+:5000")
                .Build();
    
                Startup.is_service = true;
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }
    }
