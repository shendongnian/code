    public class UserController : Controller 
    {
         public UserController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new YourDbContext())))
        {
        }
        public UserController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public ActionResult Index() { ... }
        public ActionResult Create() { ... }
       
        public ActionResult Create(UserModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    //handle success
                }
                else 
                {
                    //handle otherwise
                }
            }
        }
    }
