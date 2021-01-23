    public class AccountController : Controller 
    { 
        [Authorize(Roles="Admin")]           
        public ActionResult Index() 
        {
            return View(/* Get all users using UserManager */);
        }
        [Authorize(Roles="Admin")]   
        public ActionResult Create() 
        { 
            return View();
        }
       
        [HttpPost]
        [Authorize(Roles="Admin")]   
        public async Task<ActionResult> Create(UserModel model)
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
