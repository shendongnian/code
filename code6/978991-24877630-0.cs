    protected void SampleListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
           if(uoShowHiddenField.Value == "true") {
              HtmlGenericControl hyperlink = (HtmlGenericControl)e.item.FindControl("selectionAnchor");
              hyperlink.Visible = false;
           }
        }
    }
