    public class AccountController : Controller
    {
        . . .
        [AllowAnonymous]
        public ActionResult Register() { . . . }
        
        [Authorize]
        public ActionResult Manage() { . . . }
    
        . . .
    }
