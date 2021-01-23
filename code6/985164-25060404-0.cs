    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Find the hyperlink
            HyperLink hypUrl = (HyperLink)e.Item.FindControl("hypUrl");
              
            // Set the property
            hypUrl.NavigateUrl = "foo";
        }
    }
