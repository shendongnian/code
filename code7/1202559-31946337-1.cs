    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RepeaterCB.DataSource = new List<string> { "tom", "fred", "pijule" };
            RepeaterCB.DataBind();
        }
    }
    protected void OnCheckedChange(object sender, EventArgs e)
    {
        Response.Write("<script>alert('Fire');</script>");
    }
