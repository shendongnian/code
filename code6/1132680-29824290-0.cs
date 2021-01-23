    [RoutePrefix("api/v1")]
    public class UserController : ApiController {
        [HttpPost]
        [Route("user/session")]
        public void Login(/*...*/) {
            // ...
        }
        [HttpGet]
        [Route("user/session")]    // Note this has the same route as Login
        public SessionResult GetSession(/*...*/) {
            // ...
        }
        [HttpPost]
        [Route("user")]
        public void CreateUser(/*...*/) {
            // ...
        }
    }
