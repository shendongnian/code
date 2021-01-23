    public class UserRegisterController : Controller
    {
        private readonly IUserRegisterService _userRegisterService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRegisterController(
            UserManager<ApplicationUser> userManager,
            IUserRegisterService userRegisterService)
        {
            _userManager = userManager;
            _userRegisterService = userRegisterService;    
        }
    }
