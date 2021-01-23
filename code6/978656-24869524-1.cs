    protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (ListItemType.Item == e.Item.ItemType || ListItemType.AlternatingItem == e.Item.ItemType)
        {
            PlaceHolder twitterTemplate = (PlaceHolder)e.Item.FindControl("twitterTemplate");
            PlaceHolder itemTemplate = (PlaceHolder)e.Item.FindControl("itemTemplate");
            var item = (LifestreamItem)e.Item.DataItem;
            if (item is LifestreamTwitterItem)
            {
                twitterTemplate.Visible = true;
                
                Literal fooTwitterControl = (Literal)e.Item.FindControl("fooTwitterControl");
                // Load all twitter related controls + populate
            }
            else
            {
                itemTemplate.Visible = true;
                Literal fooItemControl = (Literal)e.Item.FindControl("fooItemControl");
                // Load all non-twitter controls + populate
            }
        }
    }
