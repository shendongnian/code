    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Boolean blnresult;
        blnresult = false;
    
        blnresult = Authentication(Login1.UserName, Login1.Password);
        if(blnresult)
        {
            e.Authenticated = true;
            
            // authenticate using Forms Authentication
            Authenticate(Login1.UserName);
    
            Response.Redirect("LandingPage.aspx");
        }
        else
        {
            e.Authenticated = false;
        }
    }
    
