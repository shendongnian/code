    [Authorize]  // This will enforce all methods inside should be authorized
    public class AuthorizeController : ApiController
    {
          //this method will only be called if user is authorized
          public IHttpActionResult GetList()
          {
             return Ok();
          }
    }
