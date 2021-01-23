    public class BaseController : Controller
    {
        public UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(base.User as ClaimsPrincipal);
            }
        }
    }
