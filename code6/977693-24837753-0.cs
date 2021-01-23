    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
    
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {           
    	if (GridViewSortDirection == SortDirection.Ascending)
    	{
    		myGridView.DataSource = GetData(e.SortExpression, SortDirection.Ascending);
    		GridViewSortDirection = SortDirection.Descending;
    	}
    	else
    	{
    		myGridView.DataSource = GetData(e.SortExpression, SortDirection.Descending);
    		GridViewSortDirection = SortDirection.Ascending;
    	};
    	myGridView.DataBind();        
    }
    
