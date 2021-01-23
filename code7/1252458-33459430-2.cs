    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager; 
        private ApplicationRoleManager _roleManager;
     
        public AccountController()
        {
        }
     
        public AccountController(ApplicationUserManager userManager, ApplicationRoleManager roleManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }
     
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
    }
