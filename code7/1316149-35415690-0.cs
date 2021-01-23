    public class ProfileController : Controller
    {
        
        private ApplicationUserManager _userManager;
        public ProfileController()
        {
            _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
