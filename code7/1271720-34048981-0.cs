    listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("LastName", -2, HorizontalAlignment.Left);
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        DataRow dr = dt.Rows[i];
        ListViewItem listitem = new ListViewItem(dr["name"].ToString());
        listitem.SubItems.Add(dr["lastname"].ToString());
        listView1.Items.Add(listitem);
    }
