    for (int i = 0; i < simIdCells.Count; i++)
    {
        int value = simIdCells[i];
        ListViewItem store = new ListViewItem(value.ToString());
        store.Tag = value;
        ListViewItem subItem = new istViewItem(value.ToString());
        subItem.Tag = value;
        store.SubItems.Add(subItem);
        form5.listViewCap.Items.Add(store);
        form5.listViewCap.Items[0].Selected = true;
        form5.listViewCap.Select();
    }
    ...
    ...
    foreach(var selectedItem in listView1.SelectedItems)
    {
        simIdElements.Add((int)selectedItem.Tag);
    }
