    protected void repRequests_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
        {
             DbDataRecord dbr = (DbDataRecord)e.Item.DataItem;
             if( Convert.ToString(DataBinder.Eval(dbr, "accepted_id")) == null )
                 ((Label)e.Item.FindControl("lbltest")).CssClass = "Some Class";
        }
    }
   
