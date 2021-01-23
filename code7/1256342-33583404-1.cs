    if (listView1.Items.Count > 0)
    {
        var displayedItem = listView1.Items[listView1.Items.Count - 1];
        txtitemid.Text = displayedItem.SubItems[0];
        txtitemdesc.Text = displayedItem.SubItems[1];
    }
    else
    {
        txtitemid.Text = "";
        txtitemdesc.Text = "";
    }
