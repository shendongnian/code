     IAuthenticationManager AuthenticationManager
     {
        get
        {
            return Request.GetOwinContext().Authentication;
        }
    }
    public IHttpActionResult UserRoles()
    {
     return ok(AuthenticationManager.User.Claims.ToList());
    }
