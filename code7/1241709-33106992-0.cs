    public void OnAuthentication(AuthenticationContext filterContext)
    {
        if (!filterContext.Principal.Identity.IsAuthenticated)
            filterContext.Result = new HttpUnauthorizedResult();
    }
