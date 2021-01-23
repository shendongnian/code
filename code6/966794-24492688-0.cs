    protected void GridView1_Sorting(object server, GridViewSortEventArgs e)
    {
        GridView1.Source.SortDescriptions.Clear();
        switch (e.SortExpression)
        {
            case "FileName":
                GridView1.Source.SortDescriptions.Add(new SortDescription("PropertyNameForAscendingOrderComparison", e.SortDirection);
                GridView1.DataBind();
            case "FileDate":
                break;
        }
    }
