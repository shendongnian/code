    var identity = (ClaimsIdentity)User.Identity;
    
    identity.RemoveClaim(identity.FindFirst("Name"));
    identity.AddClaim(new Claim("Name", value));
    
    IOwinContext context = Request.GetOwinContext();
    var authenticationContext = await context.Authentication.AuthenticateAsync(DefaultAuthenticationTypes.ApplicationCookie);
    if (authenticationContext != null)
        AuthenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = true });
