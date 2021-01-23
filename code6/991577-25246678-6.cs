    protected void mydatalist_ItemDataBound(object sender, DataListItemEventArgs e)
     {
    if (e.Item.ItemType == ListItemType.Item)
    {
        Session["dlGlobal"] = e.Item.FindControl("dl_cmt") as DataList;
    }
    }
