    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("{id}/modify")]
        public HttpResponseMessage PostModify(int id) 
        { 
           // code ...
        }
    }
