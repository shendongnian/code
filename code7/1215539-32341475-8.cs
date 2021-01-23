    private void ShowDirectoriesInListView(string path)
    {
        DirectoryInfo info = new DirectoryInfo(path);
        DirectoryInfo parent = info.Parent;
        if (parent != null) 
        {
            lvExplorer.Items.Add(new System.Windows.Forms.ListViewItem("...", 0));
        }
        foreach (DirectoryInfo dInfo in info.GetDirectories())
        {
            ListViewItem item = new System.Windows.Forms.ListViewItem(dInfo.Name, 0);
            item.Tag = dInfo.Name;
            //Add some subitems here
            System.Windows.Forms.ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = dInfo.LastWriteTime.ToShortDateString();
            item.SubItems.Add(subItem); 
            lvExplorer.Items.Add(item);
        }
    }
