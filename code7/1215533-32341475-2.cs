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
            lvExplorer.Items.Add(new System.Windows.Forms.ListViewItem(dInfo.Name, 0));
        }
    }
