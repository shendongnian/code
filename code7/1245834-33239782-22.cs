    for (int i = 0; i < 5; i++)
    {
        ListViewItem lvi = new ListViewItem("I" + i);
        ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("Link " + i);
        lvi.SubItems.Add("S" + i);
        lvsi.Name = "Link";
        lvsi.Tag  = "Test # " + i;
        listView1.Items.Add(lvi);
    }
