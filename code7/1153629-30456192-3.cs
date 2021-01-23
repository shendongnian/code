    public static class FolderExtensions
    {
        public static void RenameFolder(this Folder folder,string name)
        {
            var folderItem = folder.ListItemAllFields;
            folderItem["Title"] = name;
            folderItem["FileLeafRef"] = name;
            folderItem.Update();
        }
       
    }
