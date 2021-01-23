            List<string> folderNames = new List<string>();
            folderNames.Add("Folder 1");
            folderNames.Add("Folder 2");
            folderNames.Add("Folder 3");
            ClientContext context = new ClientContext("https://sharepoint.Site/Test");
            List list = context.Web.Lists.GetByTitle("Documents");
            var folder = list.RootFolder;
            context.Load(folder);
            context.ExecuteQuery();
            foreach (string folderName in folderNames)
            {
                ListItemCreationInformation newItemInfo = new ListItemCreationInformation();
                newItemInfo.UnderlyingObjectType = FileSystemObjectType.Folder;
                newItemInfo.LeafName = folderName;
                ListItem newListItem = list.AddItem(newItemInfo);
                newListItem["Title"] = folderName;
                newListItem.Update();
            }
            context.ExecuteQuery();
