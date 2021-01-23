    var item = listViewFields.FindItemWithText(txtSearch.Text);
    if (item != null)
    {
        listViewFields.FocusedItem = item;
        item.Selected = true;
        item.EnsureVisible();
    }
