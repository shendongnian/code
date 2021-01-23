    [Authorize]
    public class AuthorizeController : ApiController
    {
          //this method will only be called if user is authorized
          public IHttpActionResult GetList()
          {
             return Ok();
          }
          [AllowAnonymous]// This method can be called even if user is not authorized due the AllowAnonymous attribute
          public IHttpActionResult GetListUnauthorized()
          {
             return Ok();
          }
    }
