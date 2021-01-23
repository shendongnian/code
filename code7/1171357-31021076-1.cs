    public abstract class BaseApiController<T> : ApiController
    {
        public virtual IHttpActionResult Post(T model)
        {
            //custom logic here for "overriding" the 405 response
            return this.BadRequest();
        }
    }
    public class UsersController : BaseApiController<User>
    {
        public override IHttpActionResult(User model)
        {
            //do your real post here
            return this.Ok();
        }
    }
    
