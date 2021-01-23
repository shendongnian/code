    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType== DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            DropDownList ddlCategories = e.Row.FindControl("DdlCategories") as DropDownList;
            if(ddlCategories != null)
            {
                //Get the data from DB and bind the dropdownlist
                ddlCategories.SelectedValue = drv["CategoryID"].ToString();
            }
        }
    }
