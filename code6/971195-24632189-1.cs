    public void renameRecur(string destination) {
        DirectoryInfo dirInfo = new DirectoryInfo(destination);
    
        foreach(FileInfo file in dirInfo.getFiles()) {
            if(!file.Exists) //Try This.
                continue;
            file.IsReadOnly = false;
    
        }
    
        foreach(DirectoryInfo dir in dirInfo.EnumerateDirectories()) {
            renameRecur(dir.FullName);
    
        }
    }
