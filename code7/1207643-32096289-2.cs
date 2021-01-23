    //user = the user that is loggin on, retrieved from database 
    List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    //some other claims
                };
    
    ClaimsIdentity identity = new ClaimsIdentity(claims, AuthConfig.DefaultAuthType);
    IAuthenticationManager authManager = Request.GetOwinContext().Authentication;
    authManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
