    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
                if (User.Identity.IsAuthenticated && Roles.Enabled)
                {
    
                    //here we can subscribe user to a role via Roles.AddUserToRole()
                }       
        }
