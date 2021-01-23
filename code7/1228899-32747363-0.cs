    ListView parent = (ListView)sender;
    object data = parent.SelectedItems;
    
    System.Collections.IList items = (System.Collections.IList)data;
    var collection = items.Cast<UserData>();
    if (data != null)
    {
        List<string> filePaths = new List<string>(); 
        foreach (UserData ud in collection)
        {
            filePaths.Add(new System.IO.FileInfo(ud.Data.ToString()).FullName);
        }
        DataObject obj = new DataObject();
        System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
        sc.AddRange(filePaths.ToArray());
        obj.SetFileDropList(sc);
        DragDrop.DoDragDrop(parent, obj, DragDropEffects.Copy);
    }
