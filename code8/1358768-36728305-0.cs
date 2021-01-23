    protected void rptBillHeaders_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
    
        if (item.ItemType == ListItemType.Header)
        {
            ...
            e.Item.FindControl("DocHeader").Visible = false;
        }
        else if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            ...
            e.Item.FindControl("DocColumn").Visible = false;
        }
    }
