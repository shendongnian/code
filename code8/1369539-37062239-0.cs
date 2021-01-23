    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hyperlink.DataBind();
            ...
        }
    }
