    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Browser.IsMobileDevice)
            {
                Grid.Columns[0].Visible = "false";
                ....
            }
        }
    }
