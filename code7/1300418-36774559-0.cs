    public async Task<ActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated)
        {
            await SignInManager.SignOutAsync();
        }
        foreach (var key in HttpContext.Request.Cookies.Keys)
        {
            HttpContext.Response.Cookies.Append(key, "", new CookieOptions() { Expires = DateTime.Now.AddDays(-1) });
        }
        return RedirectToAction("Index", "App");
    }
