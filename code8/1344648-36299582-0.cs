    [Authorize]
    public class PrivateResourcesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(DateTime.Now);
        }             
    }
    [Authorize(Roles ="Admin",Users ="foo@mail.com")]
    public class PrivateResourcesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(DateTime.Now);
        }             
    }
