    protected virtual void titanRptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            ImageButton titanBtn = (ImageButton)e.Item.FindControl("titanBtn");
            //etc etc
            //get any values you need (eg)
            int something = (int)DataBinder.Eval(e.Item.DataItem, "something");
