    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new [] {"value1", "value2"});
        }
    
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }
    
        [HttpPost]
        [Route("validate")]
        public IHttpActionResult Validate([FromBody]string email)
        {
            return Ok(email);
        }
    }
