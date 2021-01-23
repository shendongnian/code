    public partial class MyService: ServiceBase
    {        
        AppDomain domain;
        ServiceShell runner;
        public MyService()
        {   
            var setup = new AppDomainSetup
            {
                ShadowCopyFiles = "true"
            };
            domain = AppDomain.CreateDomain("MyServiceHostDomain", AppDomain.CurrentDomain.Evidence, setup);
            runner = (ServiceShell)domain.CreateInstanceAndUnwrap
                (typeof(ServiceShell).Assembly.FullName, typeof(ServiceShell).FullName);
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {          
            runner.Run();
        }
        protected override void OnStop()
        {
            runner.Stop();
            AppDomain.Unload(domain);
        }       
    }
