    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType == DataControlRowType.Header)
    		{
    			e.Row.Cells[0].Text = "Name";
    			e.Row.Cells[1].Text = "City";
    		}
    	}
