    public class UsersController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var user = SomeMethodToGetUsersById(id);
            
            return this.Ok(user);
        }
    }
