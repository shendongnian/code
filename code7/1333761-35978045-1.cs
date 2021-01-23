    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sort"))
        {
            // add your code to sort
    	    e.CommandArgument.ToString()...
            BindGridView();
        }
    }
