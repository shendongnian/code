    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           BindGrid();
        }
    }
    private void BindGrid()
    {
        GridView1.DataSource = "Query..."
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender,GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
