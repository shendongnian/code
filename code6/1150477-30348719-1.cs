    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		//Cell#5 because your Role appears in that field (Index starts with 0)
    		if(e.Row.Cells[5].Text.Equals(1))
    			e.Row.Cells[5].Text = "Admin";
    		if(e.Row.Cells[5].Text.Equals(2))
    			e.Row.Cells[5].Text = "Guest";
    	}
    }
