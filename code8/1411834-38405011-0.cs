    HttpContext.GetOwinContext().Authentication.Challenge(
        new AuthenticationProperties
        {
            RedirectUri = "/",
            Dictionary =
            {
                { "login_hint", "abc@microsoft.com" }
            }
        });
