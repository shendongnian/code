    var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
    // add any other claims here
    
    var context = HttpContext.Current.GetOwinContext();
    var authentication = context.Authentication;
    var properties = new AuthenticationProperties();
    properties.IsPersistent = true;
                
    authentication.SignIn(properties, identity);
