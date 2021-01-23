    protected void GridView1_Sorting(object server, GridViewSortEventArgs e)
    {
        switch (e.SortExpression)
        {
            case "FileName":
                var collectionViewSource = CollectionViewSource.GetDefaultView(Session["fileData"]);
                collectionViewSource.SortDescriptions.Add(new SortDescription("PropertyNameForAscendingOrderComparison", e.SortDirection);
                GridView1.DataSource = collectionViewSource;
                GridView1.DataBind();
            case "FileDate":
                break;
        }
    }
