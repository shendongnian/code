    var subFolder = new SubFolder()
    {
        Name = file.Name,
        Folder = new Folder { Id = idFolder },
    };
    using (var db = new IncludeDatabase())
    {                
        db.SubFolders.Insert(subFolder);
    }
