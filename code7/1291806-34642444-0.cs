    foreach (DataColumn column in dt.Columns)
    {
        GridViewColumn boundColumn = new BoundColumn
        {
            DataSource = column.ColumnName,
            HeaderText = column.ColumnName,
            HtmlEncode = false
        };
        gvData.Columns.Add(boundColumn);
    }
    
    gvData.DataSource = dt;
    gvData.DataBind();
