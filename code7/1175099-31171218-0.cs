    idenityt.AddClaim(new Claim("myClaimType", "myClaimValue"));
    
    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
    authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, idenityt);
