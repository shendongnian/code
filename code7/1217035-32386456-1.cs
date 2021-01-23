    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            //sets focus to the proper control
            Page.SetFocus(Page.FindControl(_toFocus));
        }
    }
