    protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool isTopHalf = (bool)e.Item.DataItem;
            GridView gvHalf = e.Item.FindControl("gvHalf") as GridView;
            gvHalf.DataSource = isTopHalf ? dtTopHalf : dtBottomHalf;
            gvHalf.DataBind();
        }
    }
