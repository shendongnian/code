    public class BaseController : Controller
    {
        protected string _connectionName;
        protected override void Initialize(RequestContext requestContext)
        {
            if(requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                using (var db = new UserDbContext())
                {
                    _connectionName = db.Users.Find(
                        requestContext.HttpContext.User.Identity.GetUserId())
                        .ConnectionString;
                }
            }
            base.Initialize(requestContext);
        }
    }
