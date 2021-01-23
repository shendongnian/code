    public ActionResult ExternalLogin(string provider, string returnUrl)
    {
        ControllerContext.HttpContext.Session.RemoveAll();
        var redirectUri = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
        return new ChallengeResult(provider, redirectUri);
    }
