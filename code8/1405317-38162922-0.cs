    private void lv_ItemDrag(object sender, ItemDragEventArgs e)
    {
        // create array or collection for all selected items
        var items = new List<ListViewItem>();
        // add dragged one first
        items.Add((ListViewItem)e.Item);
        // optionally add the other selected ones
        foreach (ListViewItem lvi in lv.SelectedItems)
        {
            if (!items.Contains(lvi))
            {
                items.Add(lvi);
            }
        }
        // pass the items to move...
        lv.DoDragDrop(items, DragDropEffects.Move);
    }
    // this SHOULD look at KeyState to disallow actions not supported
    private void lv2_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
        {
            e.Effect = DragDropEffects.Move;
        }
    }
    private void lv2_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
        {
            var items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));
            // move to dest LV
            foreach (ListViewItem lvi in items)
            {
                // LVI obj can only belong to one LVI, remove
                lvi.ListView.Items.Remove(lvi);
                lv2.Items.Add(lvi);
            }
        }
    }
