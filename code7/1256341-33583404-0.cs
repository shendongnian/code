    if (listView1.Items.Count > 0)
    {
        var lastItem = listView1.Items[listView1.Items.Count - 1];
        txtitemid.Text = lastItem.SubItems[0];
        txtitemdesc.Text = lastItem.SubItems[1];
    }
    else
    {
        txtitemid.Text = "";
        txtitemdesc.Text = "";
    }
