    protected void dgLCL_Select(object source, DataGridCommandEventArgs e)
    	{
    		if (e.CommandName == "Refresh")
    		{
    			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    			{
    				e.Item.Cells[3].Text = "your dynamic gross weight text";
    				e.Item.Cells[5].Text = "your dynamic volumne text";
    			}
    		}
    	}
