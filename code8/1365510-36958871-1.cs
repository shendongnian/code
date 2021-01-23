    static void Main()
    {
        HostFactory.Run(c => {
            c.Service<OrleansService>(s => {
                s.ConstructUsing(sc => {
                    sc.ConfigFileName("OrleansConfiguration.xml");
    
                    //do some config at runtime if you want
                    //sc.DeploymentId("blachblahc");
                });
    
                s.WhenStarted((service, control) => service.Start());
                s.WhenStopped((service, control) => service.Stop());
            });
    
            c.RunAsLocalSystem();
    		c.UseAssemblyInfoForServiceInfo();
            c.SetServiceName("OrleansSiloHostService");
            c.StartAutomaticallyDelayed();
        });
    }
    public class OrleansService
    {
        private readonly SiloHost host;
        private Task startup;
    
        internal OrleansService(SiloHost silohost)
        { host = silohost; }
    
        public bool Start()
        {
            host.LoadOrleansConfig();
            host.InitializeOrleansSilo();
            startup = Task.Factory.StartNew(() =>
            {
                return host.StartOrleansSilo();
            });
            return true;
        }
    
        public bool Stop()
        {
            if (startup.Status == TaskStatus.RanToCompletion)
            { host.ShutdownOrleansSilo(); }
            return true;
        }
    }
