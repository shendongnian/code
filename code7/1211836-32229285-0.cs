    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Service : System.Web.Services.WebService
    {
        public Service () {
            
        }
    
        [WebMethod]
        public string HelloWorld() {
            return "Hello World";
        }
    
    }
    public partial class WindowsServiceToHostASMXWebService : ServiceBase
    {
        public WindowsServiceToHostASMXWebService()
        {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                Uri address = new Uri("soap.tcp://localhost/TestService");
                SoapReceivers.Add(new EndpointReference(address), typeof(Service ));
            }
    
            protected override void OnStop()
            {
                SoapReceivers.Clear();
            }
            static void Main()
            {
                System.ServiceProcess.ServiceBase[] ServicesToRun;
                // Change the following line to match.
                ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WindowsServiceToHostASMXWebService() };
                System.ServiceProcess.ServiceBase.Run(ServicesToRun);
            }
        }
