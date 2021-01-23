    FileAttributes attr = System.IO.File.GetAttributes(item);
    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
    {
        list.Add(new Node(Path.GetFileName(item), item, Directory.Exists(item), true));
    }
    else
    {
        string ext = item.Substring(item.LastIndexOf('.'));
        if (extentions.Contains(ext)){
            list.Add(new Node(Path.GetFileName(item), item, Directory.Exists(item)));
        }
    }
