    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
            if (Request.IsAuthenticated)
            {
                var identity = new CustomIdentity(HttpContext.Current.User.Identity);//this will force to reload the userId
                var principal = new CustomPrincipal(identity);
                HttpContext.Current.User = principal;
            }
    }
