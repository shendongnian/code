    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
    adapter.Fill(dsProducts);
    
    if (dsProducts.Tables.Count > 0)
    {
        dt1 = dsProducts.Tables[0];
    }
    dtProducts = dt1;
    
    -------------------------------------------
    protected void gvProducts_Sorting(object sender, GridViewSortEventArgs e)
    {
        sortingDirection = string.Empty;
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            sortingDirection = "Desc";
        }
        else
        {
            dir = SortDirection.Ascending;
            sortingDirection = "Asc";
        }
    
        BindData();
        DataView sortedView = new DataView(dt1);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        SortField = e.SortExpression;
        gvProducts.DataSource = sortedView;
        gvProducts.DataBind();
    }
