    //
    // POST: /Account/ExternalLogin
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult ExternalLogin(string provider, string returnUrl)
    {
        // Clear any other session first as this seems to cause unexpected null responses.
        if (ControllerContext.HttpContext.Session != null)
        {
            ControllerContext.HttpContext.Session.RemoveAll();
        }
        // Request a redirect to the external login provider
        return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
    }
