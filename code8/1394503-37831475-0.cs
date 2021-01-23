     auto query = folder.CreateFileQuery();
     query.ContentsChanged += queryContentsChanged;
.......
    void queryContentsChanged(IStorageQueryResultBase sender, object args) 
    {
        // check what was changed 
    }
