        public IActionResult Login(string returnUrl = null)
    {
        if (_signInManager.IsSignedIn(User))
        {
            // redirect to user profile page
            return RedirectToAction(nameof(HomeFileController.Index), "HomeFile");                
        }
        else
        {
            // clear Identity.External cookie
            if (Request.Cookies["Identity.External"] != null)
            {
                Response.Cookies.Delete("Identity.External");
            }
            return View(new LoginViewModel{ ReturnUrl = returnUrl, RememberMe = true });
        }
}
