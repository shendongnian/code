    public class AccountController : Controller
    {
        UserManager _userManager;
    
        public AccountController(UserManager userManager)
        {
            _userManager = userManager;
        }
    
        [HttpPost]
        public IActionResult LogIn(LogInViewModel form)
        {
            if (!ModelState.IsValid)
                return View(form);
             try
            {
                //authenticate
                var user = new UserDbModel()
                {
                    UserEmail = form.Email,
                    UserCellphone = form.Cellphone,
                    UserPassword = form.Password
                };
                _userManager.SignIn(this.HttpContext, user);
                 return RedirectToAction("Search", "Home", null);
             }
             catch (Exception ex)
             {
                ModelState.AddModelError("summary", ex.Message);
                return View(form);
             }
        }
    }
