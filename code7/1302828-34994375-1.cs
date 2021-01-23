    if (!IsPostBack)
        createSession();
    else
    {   
        Session["PagesViewed"] = (int)Session["PagesViewed"]+ 1;
    }
    pageCounter.Text = Session["PagesViewed"].ToString();
