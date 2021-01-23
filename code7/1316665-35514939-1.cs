    protected void Page_Load(object sender, EventArgs e)
    {
        // ...
        if (!Page.IsPostBack)
        {
            // get data
            gvCVRT.DataSource = tbl;
            gvCVRT.DataBind();
        }
        // ...
    }
