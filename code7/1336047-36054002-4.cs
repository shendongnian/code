    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return Login();
        }
    
        [Route("Login")]
        public ActionResult Login2()
        {
            return Login();
        }
    }
