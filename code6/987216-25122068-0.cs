    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            // Must be authorized
        }
        public ActionResult Users()
        {
            // Must be authorized
        }
    }    
    
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            // Doesn't require authorization
        }
        [Authorize]
        public ActionResult Products()
        {
            // Must be authorized
        }
    }
