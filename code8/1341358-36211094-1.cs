    [RoutePrefix("api/login")]
    public class LoginApi : ApiController
    {
        //eg:POST api/login/authenticate.
        [HttpPost]
        [Route("authenticate")]
        public string Authenticate(LoginViewModel loginViewModel)
        {  
            return "Hello World"; 
        }
    }
