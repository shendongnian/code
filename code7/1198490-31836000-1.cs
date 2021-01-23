    protected void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item.ItemType == Telerik.Web.UI.GridItemType.CommandItem) {
       	    //This is the icon with the plus (+) sign unless you've changed the icon
       	    Button iconButton = e.Item.FindControl("AddNewRecordButton");
       	    if (iconButton != null) {
       		    iconButton.OnClientClick = "";
       	    }
       	    //This is the words "Add New Record" or whatever you've called it
       	    LinkButton wordButton = e.Item.FindControl("InitInsertButton");
       	    if (wordButton != null) {
       		    wordButton.OnClientClick = "";
     	    }
        }
    }
