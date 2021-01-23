    protected void createSession()
    {
        if(Session["PagesViewed"] == null)
        {
            Session["PagesViewed"] = 0;
        }
    }
