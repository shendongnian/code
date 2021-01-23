    List<ListViewItem> listViewItemHandles = new List<ListViewItem>();
    for(int i = 0; i < 10; i++)
    {
        ListViewItem lvi = new ListViewItem(taskName2);
        lvi.SubItems.Add(DateTime2);
        lvi.SubItems.Add(More2);
        listView1.Items.Add(lvi);
        listViewItemHandles.Add(lvi);
    }
    
