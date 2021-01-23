    protected void CloudTags_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (CloudTags.Items.Count > 10)
            {
                HyperLink HyperLink9 = (HyperLink)e.Item.FindControl("HyperLink9");
                HyperLink9.CssClass = "some-class";
            }
        }
    }
