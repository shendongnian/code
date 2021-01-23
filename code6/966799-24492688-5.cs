    protected void GridView1_Sorting(object server, GridViewSortEventArgs e)
    {
        switch (e.SortExpression)
        {
            case "FileName":
                var dataTable = ToDataTable((IList<ListItem>)Session["fileData"]);
                var dataView = new DataView(dataTable);
                dataView.Sort = string.Format("{0} {1}", 
                    e.SortExpression, 
                    e.SortDirection == SortDirection.Ascending 
                        ? "ASC" : "DESC");
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            case "FileDate":
                break;
        }
    }
