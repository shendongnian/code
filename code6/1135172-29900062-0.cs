    protected void listview_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
           var btn_edit = e.Item.FindControl("EditButton") as Button;
    
           if (isOwner == false)
           {
             // code here..
           }
           else
           {
             btn_edit.Enabled = true;
             btn_edit.Visible = true;
           }
    
        }
    }
