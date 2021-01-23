    public ActionResult SignOut() {
        var authenticationTypes = new string[] {
            DefaultAuthenticationTypes.ApplicationCookie,  
            DefaultAuthenticationTypes.ExternalCookie 
        };
        AuthenticationManager.SignOut(authenticationTypes);
        // HACK: Prevent user from being able to go back to a logged in page once logged out
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        // now redirect
        return RedirectToAction("Index", "Home");    
    }
    private IAuthenticationManager AuthenticationManager {
        get {
            return Request.GetOwinContext().Authentication;
        }
    }
