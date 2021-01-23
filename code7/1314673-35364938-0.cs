        public void RemoveFolder(Folder folder, List<Folder> folderList)
        {
            if (folderList != null)
            {
                if (folderList.Contains(folder))
                {
                    folderList.Remove(folder);
                }
                else
                {
                    foreach (var subFolder in folderList.Select(x => x.subFolders))
                    {
                        RemoveFolder(folder, subFolder);
                    }
                }
            }
        }
    
