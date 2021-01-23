    public partial class Service1 : ServiceBase, IService1
    {
        internal static ServiceHost myServiceHost = null;
        //this is the master config that the service uses
        public ConfigSettings myConfig = new ConfigSettings();
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
            }
            myServiceHost = new ServiceHost(typeof(Service1));
            myServiceHost.Open();
            //change master settings from null
            myConfig.Setting1 = "123";
            myConfig.Setting2 = "456";
        }
        protected override void OnStop()
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
                myServiceHost = null;
            }
        }
        public ConfigSettings GetConfig()
        {
            return myConfig;
        }
    }
