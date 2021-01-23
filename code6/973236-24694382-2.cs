    public static int Theme
    {
        get
        {
            if(Session["Theme"] == null)
                return 0;// Or an alternate default value.
            return (int)Session["Theme"];
        }
        set { Session["Theme"] = value; }
    }
