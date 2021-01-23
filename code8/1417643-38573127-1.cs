    [RoutePrefix("api/users")]
    public class UsersController : ApiController {
    
        [Route("")]
        public IHttpActionResult Get() { ... }
    
    
        [Route("{id}")]
        public IHttpActionResult Get(int id) { ... }
    
        [AllowAnonymous]
        [HttpPost]
        [Route("validate")]
        public IHttpActionResult Validate(string email) { ... }
    
    }
