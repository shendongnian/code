    public class BaseApiController : ApiController
    {
        protected virtual new UserPrincipal User
        {
            get { return base.User as UserPrincipal ?? new UserPrincipal("defaultuser"); }
        }
    }
