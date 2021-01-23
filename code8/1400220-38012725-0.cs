    protected void gridview_Sortingevent()
    {
        // BIND Data with Gridview
        GridViewDataBind();
    
        DataTable dt = gridview.DataSource as DataTable;
    
        if (dt != null)
        {
            //Sort the data.
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
    
            Session["sessionsort"] = dt.DefaultView.Sort;
            gridview.DataSource = dt;
            gridview.DataBind();
        }
    }
