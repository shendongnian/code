    protected void Session_End(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
                    AuthenticationManager.SignOut();
        }
    }  
