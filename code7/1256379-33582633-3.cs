    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		PopulateGrid();
    	}
    }
    
    private void PopulateGrid()
    {
    	gvSample.DataSource = Enumerable.Range(0, 10).Select(i => new { RowValue = i });
    	gvSample.DataBind();
    }
    
    protected void PerformOperation(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "MyCustomCommand")
    	{
    			var rowIndex = int.Parse(e.CommandArgument);
				lblMsg.Text = string.Format("Button on row index: {0} was clicked!", rowIndex);
    	}
    }
