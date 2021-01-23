    private const int fixedColumnCount = 2; // Sort command + Row number
    private int sortRowIndex = -1;
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SortRow")
        {
            sortRowIndex = Convert.ToInt32(e.CommandArgument);
            // Here set the data source and bind the data to the GridView
            GridView1.DataSource = ...
            GridView1.DataBind();
        }
    }
