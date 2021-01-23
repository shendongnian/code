    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridFilteringItem)
        {
            updateComboBox.DataBind();
            updateComboBox.SelectedValue = e.Item.OwnerTableView.GetColumn("Id").CurrentFilterValue;
        }
    }
