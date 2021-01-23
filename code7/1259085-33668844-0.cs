    public bool UserIsLoggedIn
    {
        get
        {
            if (Session["loggedIn"] != null)
            {
                return Convert.ToBoolean(Session["loggedIn"]);
            }
    
            return false;
        }
        set
        {
            Session["loggedIn"] = value;
        }
    }
