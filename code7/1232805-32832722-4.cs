    public GridViewRow TheSelectedRow
    {
        get { return Session["TheSelectedRow"] == null ? null : Session["TheSelectedRow"] as GridViewRow; }
        set { Session["TheSelectedRow"] = value; }
    }
