    public static MvcHtmlString GetUsersFirstAndLastName(this HtmlHelper helper)
    {
        string fullName = HttpContext.Current?.User?.Identity?.Name ?? string.Empty;
    
        var userIdentity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        var nameClaim = identity?.FindFirst("fullname");
    
        var authenticationManager = HttpContext.GetOwinContext().Authentication;
        authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });
     
        if (nameClaim != null)
        {
            fullName = nameClaim.Value;
        }
    
        return MvcHtmlString.Create(fullName);
    }
