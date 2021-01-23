    public int Turn
    {
        get
        {
            if (Session["Turn"] == null)
                Session["Turn"]= 0;
            return (int)Session["Turn"];
        }
        set
        {
            Session["Turn"] = value;
        }
    }
