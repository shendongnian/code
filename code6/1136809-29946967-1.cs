	 protected void rpter_ItemCreated(Object sender, RepeaterItemEventArgs e)
			{
				if (e.Item.ItemType == ListItemType.Footer)
				{    
				  e.Item.FindControl(ctrl);
				}
				if (e.Item.ItemType == ListItemType.Header)
				{
				  e.Item.FindControl(ctrl);
				}
	}
