    try
    {
        Folder dir = shell.NameSpace(directory);
        FolderItem fi = (dir as Folder3).Self;
        string path = fi.Path;
        List<string> list = new List<string>();
        foreach (FolderItem curr in dir.Items())
        {
            list.Add(curr.Name);
        }
        folderItems = list.ToArray();
    }
    catch (Exception e)
    {
        MessageBox.Show(e.ToString());
    }
