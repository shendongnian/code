    try
    {
        Folder dir = shell.NameSpace(directory);
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
