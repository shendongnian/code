    void rptAnimalPatients_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {    
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;
       	var tdOwner= (HtmlGenericControl)e.Item.FindControl("tdOwner");
        tdOwner.Visible=//make code to true or false
    }
