    protected void GridViewAbout_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // this to skip on paging or sorting command
        if (e.CommandName != "Sort" & e.CommandName != "Page")
        {
            // Get the command argument where the index of the clicked button is stored
            int index = Convert.ToInt32(e.CommandArgument);
            // Get the data key of the index where the id is stored
            int id = Convert.ToInt32(GridViewAbout.DataKeys[index].Value);
            if (e.CommandName == "SelectSession")
            {
                // Your Code
            }
        }
    }
