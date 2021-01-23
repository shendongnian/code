    public static PageContext ForCurrentSession
    {
        get 
        {
            if(Session["PageContext"] == null)
            {
                Session["PageContext"] = new PageContext();
            }
            return Session["PageContext"] as PageContext;
        }
    }
