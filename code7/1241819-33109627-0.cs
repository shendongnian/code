    [Authorize] 
    public class AccountController : Controller
    {
        public AccountController () { . . . }
        
        [AllowAnonymous]
        public ActionResult Register() { . . . }
    
        public ActionResult Manage() { . . . }
    
        public ActionResult LogOff() { . . . }
    . . .
    }
