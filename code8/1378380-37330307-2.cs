    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("{id:int}/modify")]
        public HttpResponseMessage PostModify(int id) 
        { 
           // code ...
        }
    }
