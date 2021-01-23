    [RoutePrefix("api/users")]
    public class UsersController : ApiController {
    
        //GET api/users
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get() { ... }
        //GET api/users/5    
        [HttpGet]    
        [Route("{id}")]
        public IHttpActionResult Get(int id) { ... }
    
        //POST api/users/validate?email=someone@email.com
        [AllowAnonymous]
        [HttpPost]
        [Route("validate")]
        public IHttpActionResult Validate(string email) { ... }
    
    }
