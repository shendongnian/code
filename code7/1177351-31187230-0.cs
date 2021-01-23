    public static class ListExtensions
    {
        public static void CreateFolder(this List list, string name)
        {
            var info = new ListItemCreationInformation
            {
                UnderlyingObjectType = FileSystemObjectType.Folder,
                LeafName = name
            };
            var newItem = list.AddItem(info);
            newItem["Title"] = name;
            newItem.Update();
        }
    }
