    var folder = root.GetDirectoryReference("myfolder");
    if (folder.Exists()) {
        foreach (var item in folder.ListFilesAndDirectories()) {         
            if (item.GetType() == typeof(CloudFile))
            {
                CloudFile file = (CloudFile)item;
                // Do whatever
            }
            else if (item.GetType() == typeof(CloudFileDirectory))
            {
                CloudFileDirectory dir = (CloudFileDirectory)item;
                // Do whatever
            }
        }
    }
