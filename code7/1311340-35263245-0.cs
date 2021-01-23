    void protected OnLogin()
    {
        if(UserIsAuthenticated)
        {
            Session["English"] = true;
        }
    }
