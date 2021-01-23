    public class Program
    {
        public static void Main(string[] args)
        {
            
            if (args.Contains("--service"))
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Directory.SetCurrentDirectory(path); // need this because WebHost.CreateDefaultBuilder queries current directory to look for config files and content root folder. service start up sets this to win32's folder.
                var host = CreateWebHostBuilder(args).Build();
                host.RunAsService();
            }
            else
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
