       [RoutePrefix("api/Rest")]
        [Authorize]
        public class RestController : ApiController
        {
             [Route("{name}/GetName")]
             public IHttpActionResult GetName(string name = null) 
             {
             // cut - code here is trivial but long, I just fill in an object
             to  return as Json code
             return Json(myObject);
             }
         }
