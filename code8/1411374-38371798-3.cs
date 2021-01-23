    #if DEBUG
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            var identity = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "Testy McTestface"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "testUser"));
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut("ApplicationCookie");
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
            return Redirect("Home/Index");
        }
    #endif
