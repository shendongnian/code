    using System.ServiceModel;
    using System.ServiceProcess;
    
    namespace WindowsServiceTest
    {
        public partial class Service1 : ServiceBase
        {
            internal static ServiceHost myServiceHost = null;
    
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
                myServiceHost = new ServiceHost(typeof(WCFService1 ));
                myServiceHost.Open();
    
    
            }
    
            protected override void OnStop()
            {
                if (myServiceHost != null)
                {
                    myServiceHost.Close();
                    myServiceHost = null;
                }
            }
        }
    
        public class WCFService1 : IService1
        {
            public WCFService1()
            {
                //change master settings from null
                myConfig.Setting1 = "123";
                myConfig.Setting2 = "456";
            }
    
            //this is the master config that the service uses
            public ConfigSettings myConfig = new ConfigSettings();
    
            public ConfigSettings GetConfig()
            {
                return myConfig;
            }
        }
    
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            ConfigSettings GetConfig();
        }
    
        public class ConfigSettings
        {
            public string Setting1 { get; set; }
            public string Setting2 { get; set; }
    
            public ConfigSettings()
            { }
        }
    }
