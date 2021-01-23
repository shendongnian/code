    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        var context = HttpContext.Current;
    
        if (context.User != null && context.User.Identity != null && context.User.Identity.IsAuthenticated)
        {
            if (SomeClass.UserIsExpired(context.User))
            {
                // Clear cookies or whatever you need to do
                // Throw a 401 to deny access
                throw new HttpException(401, "User account is expired");
            }
        }
    }
