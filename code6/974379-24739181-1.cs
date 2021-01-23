    protected void cValidation_ServerValidate(object source, ServerValidateEventArgs args)
    {
    	bool isValid = true;
    	//Here you can loop through each item
    	foreach (RepeaterItem item in rptLightRefreshments.Items)
    	{
    		//
    		if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
    		{
    			//Get the controls
    			Label lblItem = item.FindControl("lblItem") as Label;
    			TextBox txtQuantity = item.FindControl("txtQuantity") as TextBox;
    			//Do your validation
    		}
    	}
    	//Finally set the result to args
    	args.IsValid = isValid;
    }
