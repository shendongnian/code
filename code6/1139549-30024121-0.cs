    protected void gdvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //removed the foreach loop
        var row = e.Row;
        if (row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < row.Cells.Count; i++) //changed index
            {
                var dlRouteType = new DropDownList();
                dlRouteType.ID = "ddlRouteType_" + i; //gave unique id
                dlRouteType.DataSource = GetRouteTypeList();
                dlRouteType.DataTextField = "RouteType";
                dlRouteType.DataValueField = "Id";
                dlRouteType.DataBind();
                row.Cells[i].Controls.Add(dlRouteType);
            }
        }
    }
