    protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
             string val = ((Label)e.Item.FindControl("lblValue")).Text;
            // Some Stuff
        }
    }
