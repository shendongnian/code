    public class AuthController : Controller
    {
        private SignInManager<MyLegacyUserUser> _signInManager;
       
        public AuthController(SignInManager<MasterUser> signInManager)
        {
            _signInManager = signInManager;
        }
        // For simplicity I will only add the Login action here
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, false);
            if (result == SignInResult.Success)
            {
                return RedirectToAction("Index", "SomeControllerToRedirectTo");
            }
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
