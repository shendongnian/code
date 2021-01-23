    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		if(e.Row.Cells[5].Text.Equals(1))
    			e.Row.Cells[5].Text = "User";
    		if(e.Row.Cells[5].Text.Equals(2))
    			e.Row.Cells[5].Text = "Admin";
    	}
    }
