    protected void Ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl1 = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl1.NamingContainer;
        DropDownList ddl2 = (DropDownList)row.FindControl("DropDownList2ID");
        // here get the datasource for ddl2 according to ddl1.SelectedValue
        ddl2.DataSource = GetDataSource(ddl1.SelectedValue);
        ddl2.DataBind();
    }
    protected void Ddl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl2 = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl2.NamingContainer;
        DropDownList ddl3 = (DropDownList)row.FindControl("DropDownList3ID");
        // here get the datasource for ddl3 according to ddl1.SelectedValue
        ddl3.DataSource = GetDataSource(ddl2.SelectedValue);
        ddl3.DataBind();
    }
