    public class ProfileController : Controller
    {
        private readonly MyClient _client;
        public ProfileController()
        {
            var clientInfo = Resolve<IClientInfo>(); // call out to your service locator
            _client = clientInfo.GetClient();
        }
    }
    public interface IClientInfo
    {
        MyClient GetClient();
    }
    public class ClientInfo : IClientInfo
    {
        public MyClient GetClient()
        {
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var myClient = new MyClient(apiKey);
            // This will not work as this code is executed on app start
            // The identity will not be of the user making the web request
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            var tokenClaim = identity.Claims.First(c => c.Type == ClaimTypes.Sid);
            client.AddCredentials(tokenClaim.Value);
            return myClient;
        }
    }
