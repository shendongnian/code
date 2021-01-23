    private void listView2_ItemDrag(object sender, ItemDragEventArgs e)
    {
        // stuff all seleted items into an array
        var Items = listView2.SelectedItems.Cast<ListViewItem>().ToArray();
        DataObject data = new DataObject(DataFormats.FileDrop, Items);
        data.SetData(Items);
        listView1.DoDragDrop(data, DragDropEffects.Move);  // move or copy?
    }
    private void listView1_DragEnter(object sender, DragEventArgs e)
    {
        // if we receive an array of ListViewItems show we are ready to move (or copy?)
        if (e.Data.GetDataPresent(typeof(ListViewItem[]))) e.Effect = DragDropEffects.Move;
    }
    private void listView1_DragDrop(object sender, DragEventArgs e)
    {
        var data = e.Data.GetData(typeof(ListViewItem[]));
        ListViewItem[] items = data as ListViewItem[];
        // data ok?
        if (items != null)
        // now loop over the array..
            foreach (ListViewItem lvi in items)
            {
                // do stuff.. here we can check where we come from:
                listView1.Items.Add(lvi.Text + " coming from " + lvi.ListView.Name)
            }
    }
