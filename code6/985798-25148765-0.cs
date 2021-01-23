    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "Test")
        {
            GridDataItem item = (GridDataItem)e.Item;
            string columnWhateverValue = item["Whatever"].Text;
        }
    }
