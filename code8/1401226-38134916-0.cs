     public static void Main(string[] args) {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://192.168.0.0:8080")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
