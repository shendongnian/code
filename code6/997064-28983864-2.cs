                public class AccountController : Controller
    {
        private readonly UserManager _userManager = UserManager.CreateUserManager();
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(string userId, string token, FormCollection collection)
        {
            var result = await _userManager.ResetPasswordAsync(user.Id, HttpUtility.UrlDecode(token), newPassword);
            if (result != IdentityResult.Success)
                return Content(result.Errors.Aggregate("", (current, error) => current + error + "\r\n"));
            return RedirectToAction("Login");
        }
