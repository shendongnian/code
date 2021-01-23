        public ActionResult CheckSessionTimeout() => View();
        public ActionResult ForceSessionRefresh()
        {
            HttpContext.GetOwinContext()
                   .Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/Home/CheckSessiontimeout" },
                       OpenIdConnectAuthenticationDefaults.AuthenticationType);
            return null;
        }
