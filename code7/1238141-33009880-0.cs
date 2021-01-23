     public static void Main(string[] args)
    {
        HostFactory.Run(x =>
        {
            x.Service<ZipPackService>(s =>
            {
                s.ConstructUsing(name => new ZipPackService(new ServiceRepository(new FileHelper())));
                s.WhenStarted((tc, hostControl) => tc.Start(hostControl));
                s.WhenStopped((tc, hostControl) => tc.Stop(hostControl));
            });
            x.RunAsLocalSystem();
            x.StartAutomaticallyDelayed();
            x.SetDescription("9 Angle Zip Refresh");
            x.SetDisplayName("ZipPack");
            x.SetServiceName("ZipPack");
        });
    }
