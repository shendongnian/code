    public class AccountController : Controller
    {
        public ActionResult Login()
        {
        }
    
        [Authorize]
        public ActionResult Logout()
        {
        }
    }
