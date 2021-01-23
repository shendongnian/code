        static void Main(string[] args)
        {
            string teamProjectCollectionUrl = "http://myserver:8080/tfs/DefaultCollection";
            string serverPath = "$/My Project/My SubFolder";
            string localPath = @"c:\temp\download";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(teamProjectCollectionUrl));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            foreach (Item item in versionControlServer.GetItems(serverPath, VersionSpec.Latest, RecursionType.Full, DeletedState.NonDeleted, ItemType.Any, true).Items)
            {
                string target = Path.Combine(localPath, item.ServerItem.Substring(2));
                if (item.ItemType == ItemType.Folder && !Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }
                else if (item.ItemType == ItemType.File)
                {
                    item.DownloadFile(target);
                }
            }
        }
