    ImageList il = new ImageList();
    il.ImageSize = new Size(1, bmpOff.Height);
    listView3.SmallImageList = il;
    for (int c = 0; c < listView3.Columns.Count; c++)
             listView3.Columns[c].Width = bmpOff.Width;
    for (int i = 0; i < listView3.Columns.Count; i++)
    {
        ListViewItem lvi = new ListViewItem( (i % 2 == 0).ToString() );
        for (int c = 0; c < 5; c++)
        {
            lvi.SubItems.Add( ( (c+i) % 2 == 0).ToString());
            lvi.SubItems[c].Tag = "3/7";
        }
        lvi.Tag = "3/7";
        listView3.Items.Add(lvi);
    }
    listView3.Width = listView3.Columns.Count * bmpOff.Width + 4;
