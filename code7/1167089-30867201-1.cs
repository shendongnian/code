    protected void listOtherImages_DataBound(object sender, ListViewItemEventArgs e)
    {
    	if(e.Item.ItemType == ListViewItemType.DataItem )
    	{
    		try
    		{
    			// find controls
    			Image prodImage = (Image)e.Item.FindControl("supImg");
    			HyperLink picLink = (HyperLink)e.Item.FindControl("imgLink");
    			// assign value to NavigateUrl
    			picLink.NavigateUrl = "~/ProductCatalogue/prodImage.aspx?ImageId=" + prodImage.AlternateText;
    
    		}
    		catch (Exception err)
    		{
    			lblError.Text = "Error finding controls: " + err.Data + "<br />" + err.Message + "<br />" + err.InnerException;
    		}
    
    
    	}
    }
