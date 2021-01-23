    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
    	if (e.Item is GridCommandItem)
    	{
    		LinkButton lnk = (LinkButton)e.Item.FindControl("InitInsertButton");
    		lnk.Attributes.Add("onClick", "return testClick()");
    	}
    }
