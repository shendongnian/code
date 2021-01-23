    users user
    {
        get
        {
            return Session["new"] as users;
        }
        set
        {
            Session["new"] = value;
        }
    }
