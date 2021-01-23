    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Button btnTemplate = (Button)e.Item.FindControl("ButtonItemTemplate");
            if (btnTemplate != null) { btnTemplate.Text = "Placed Form End Tag"; }
        }
    }
