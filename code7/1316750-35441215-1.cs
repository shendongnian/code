    public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string userId = e.CommandArgument.ToString();
            //do something with the id
        }
    }
