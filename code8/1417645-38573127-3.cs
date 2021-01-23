    [RoutePrefix("api/users")]
    public class UsersController : ApiController {
    
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get() { ... }
    
        [HttpGet]    
        [Route("{id}")]
        public IHttpActionResult Get(int id) { ... }
    
        [AllowAnonymous]
        [HttpPost]
        [Route("validate")]
        public IHttpActionResult Validate(string email) { ... }
    
    }
