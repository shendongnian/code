    public void OnAuthentication(AuthenticationContext filterContext)
    {
        ... your stuff about the AllowAnonymousActionFilter comes here
    
        var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie == null)
        {
            // Unauthorized
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary() { { "controller", "Account" }, { "action", "Login" } });
            return;
        }
    
        // Get the forms authentication ticket.
        var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        Contracts.ISer user = Deserialize(authTicket.UserData); // Up to you to write this Deserialize method -> it should be the reverse of what you did in your Login action
    
        filterContext.HttpContext.User = user;
    }
