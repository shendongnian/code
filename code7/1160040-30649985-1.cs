    users user
    {
        get
        {
            if(Session["new"] != null)
                return Session["new"] as users;
            }else{
                return null;
        }
        set
        {
            Session["new"] = value;
        }
    }
