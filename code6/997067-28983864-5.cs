        public class AccountController : Controller
    {
        private readonly UserManager _userManager = UserManager.CreateUserManager(); 
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(FormCollection collection)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { area = "", UserId = user.Id, token = HttpUtility.UrlEncode(token) }, Request.Url.Scheme);
            Mail.Send(...);
        }
