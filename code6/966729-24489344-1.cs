    protected void ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Label label12 = (Label)e.Item.FindControl("label12");
            // ...
        }
    }
