    if (listView1.Items.Count > 0)
    {
        var displayedItem = listView1.Items[listView1.Items.Count - 1];
        txtitemid.Text = displayedItem.SubItems[0].Text;
        txtitemdesc.Text = displayedItem.SubItems[1].Text;
    }
    else
    {
        txtitemid.Text = "";
        txtitemdesc.Text = "";
    }
