    protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        GridView grid = (GridView) sender;
        GridViewRow row = grid.Rows[rowIndex];
        // now you can use row.FindControl
    }
