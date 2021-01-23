    public interface IProvideAuthenticationService
    {
        IAuthenticationService GetService(string requestMethod);
    }
    public class AuthenticationServiceProvider : IProvideAuthenticationService
    {
        public IAuthenticationService GetService(string requestMethod)
        {
            switch (requestMethod)
            {
                case "GET":
                    return new HttpGetAuthenticationService();
                case "POST":
                    return new HttpPostAuthenticationService();
                default:
                    throw new NotSupportedException(string.Format("Cannot find AuthenticationService for requestMethod '{0}'", requestMethod));
            }
        }
    }
    
    public class AuthenticateController : ApiController
    {
        private readonly IProvideAuthenticationService _authenticationServiceProvider;
    
        public AuthenticateController(IProvideAuthenticationService authenticationServiceProvider)
        {
            _authenticationServiceProvider = authenticationServiceProvider;
        }
    
        [HttpGet]
        public ActionResult Get()
        {
            IAuthenticationService authService = _authenticationServiceProvider.GetService("GET");
        }
    
        [HttpPost]
        public ActionResult Post()
        {
            IAuthenticationService authService = _authenticationServiceProvider.GetService("POST");
        }
    }
