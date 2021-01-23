    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
    if (e.Item.ItemType == ListViewItemType.DataItem)
    {
    LinkButton btnTaskTitle = e.Item.FindControl("TaskTitle") as LinkButton;
    if btnTaskTitle != null)
    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btnTaskTitle );
    }
    }
