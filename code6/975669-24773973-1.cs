    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = 0;
        GridViewRow row;
        GridView grid = sender as GridView;
        switch (e.CommandName)
        {
            case "Edit":
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                //use row to find the selected controls you need for edit, update, delete here
                // e.g. HiddenField value = row.FindControl("hiddenVal") as HiddenField;
                break;
        }
    }
