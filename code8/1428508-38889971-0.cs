            ParentFolder.Context.Load(ParentFolder);
            ParentFolder.Context.Load(ParentFolder.Folders);
            ParentFolder.Context.Load(ParentFolder.Files);
     I was missing this     >>>>          ParentFolder.Context.Load(ParentFolder.Files, items => items.Include(item => item.ServerRelativePath));
            ParentFolder.Context.ExecuteQuery();
