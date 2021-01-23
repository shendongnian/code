    protected void gvtotqty_onrowdatabound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType == DataControlRowType.DataRow)
    		{
    			e.Row.Attributes["onclick"] = "selectRow(this);";
    			e.Row.ToolTip = "Click to select this row.";
    		}
    
    	}
