    public class BaseController : Controller
    {
        protected readonly IAccountContext _db          
        protected override void Initialize(RequestContext requestContext)
        {
            if(requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                using (var db = new UserDbContext())
                {
                    var connectionName = db.Users.Find(
                        requestContext.HttpContext.User.Identity.GetUserId())
                        .ConnectionString;
                    _db = new MainContext(connectionName);
                }
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
