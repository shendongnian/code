    [RouteArea("Client")]
    [RoutePrefix("login")]
    [Route("{action}")]
    public class LoginController : Controller
    {
    
        [Route("")]
        // GET: Client/Login
        public ActionResult Index()
        {
            return View();
        }
    
        [Route("register")]
        // GET: client/login/register
        public ActionResult SignUp()
        {
            return View();
        }
    }
