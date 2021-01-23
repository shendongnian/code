        protected void ListViewMenu_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem listViewDataItem = e.Item as ListViewDataItem;
            HtmlGenericControl divControl = e.Item.FindControl("MYDIV") as HtmlGenericControl;
            DataRowView dataRow = ((DataRowView)listViewDataItem.DataItem);
            divControl.Attributes.Add("class", dataRow["CLASS"].ToString());
        }
    }
