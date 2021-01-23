    protected void lnkGroupRemove(object sender, EventArgs e)
    {
        ListViewItem item = (sender as LinkButton).NamingContainer as ListViewItem;
        int ID = (int)lvGroups.DataKeys[item.DataItemIndex].Values["ID"];
        string groupName = (string)lvGroups.DataKeys[item.DataItemIndex].Values["GroupName"];
    }
