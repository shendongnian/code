    protected void Page_Load(object sender, EventArgs e)
    {
        rptImages.DataSource = Sitecore.Context.Item.GetChildren(); // this needs to be changed to whatever your query is...
        rptImages.DataBind();
    }
