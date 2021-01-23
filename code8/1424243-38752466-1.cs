    public class AuthorizeController : ApiController
    {
          [Authorize] //this method will only be called if user is authorized
          public IHttpActionResult GetList()
          {
             return Ok();
          }
          // This method can still be called even if user is not authorized
          public IHttpActionResult GetListUnauthorized()
          {
             return Ok();
          }
    }
