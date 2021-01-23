    [RoutePrefix("login")]
    public class LoginApi : ApiController
    {
        //eg:POST login/authenticate.
        [HttpPost]
        [Route("authenticate")]
        public string Authenticate(LoginViewModel loginViewModel)
        {  
            return "Hello World"; 
        }
    }
