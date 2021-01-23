    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var multiView = (MultiView)e.Item.FindControl("multiView");
            multiView.ActiveViewIndex = ((Item)e.Item.DataItem).Index % 2;
        }
    }
