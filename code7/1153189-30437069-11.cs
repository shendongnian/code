    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //Install service
                if (args[0].Trim().ToLower() == "/i")
                { System.Configuration.Install.ManagedInstallerClass.InstallHelper(new[] { "/i", Assembly.GetExecutingAssembly().Location }); }
                //Uninstall service                 
                else if (args[0].Trim().ToLower() == "/u")
                { System.Configuration.Install.ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location }); }
            }
            else
            {
                var servicesToRun = new ServiceBase[] { new MyService() };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
