    Folder.Select(F => new
            {
                FolderName = F.FolderName,
                SubFolders = F.SubFolders.Take(5)
            }).ToList().Select(F => new Folder()
            {
                FolderName = F.FolderName,
                SubFolders = F.SubFolders
            };
