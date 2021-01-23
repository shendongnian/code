    ListViewItem CopyLVI(ListViewItem lvi)
    {
        ListViewItem lviCopy = new ListViewItem(lvi.Text);
        lviCopy .Name = lvi.Name;
        for(int i = 1; i < lvi.SubItems.Count; i++)
        {
            ListViewItem.ListViewSubItem lsi = lvi.SubItems[i];
            ListViewItem.ListViewSubItem lvsiCopy = lviCopy .SubItems.Add(lsi.Text);
            lvsiCopy .Name = lsi.Name;
            // .. (*)
        }
        return lviCopy ;
    }
