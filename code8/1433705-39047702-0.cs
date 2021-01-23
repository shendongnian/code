    public class Program
    {
        public static void Main(string[] args)
        {
            // call custom startup logic here
            AppInitializer.Startup();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
