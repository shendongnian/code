        public static void Main(string[] args)
        {
            var exePath= System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var directoryPath = Path.GetDirectoryName(exePath);
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(directoryPath)
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
