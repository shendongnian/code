    protected void repMonths_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // We only care if the repeater item is part of the <ItemTemplate>
        if(e.Item.ItemType == ListItemType.Item)
        {
            Repeater repInnerEvent = (Repeater)e.Item.FindControl("repInnerEvent");
            repInnerEvent.DataSource = // your data source
            repInnerEvent.DataBind();
        }
    }
