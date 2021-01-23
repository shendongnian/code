    protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            GridViewRow row = (e.CommandSource as Control).NamingContainer as GridViewRow;
            int ID = (int)gridView1.DataKeys[row.RowIndex].Values["ID"];
            ...
        }
    }
