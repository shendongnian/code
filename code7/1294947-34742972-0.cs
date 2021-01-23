    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Item || 
                                          e.Item.ItemType == ListItemType.AlternatingItem)
       {
            Repeater Repeater2 = (Repeater)(e.Item.FindControl("Repeater2"));
            Repeater2.DataSource = CD;
            Repeater2.DataBind();
       }
    }
