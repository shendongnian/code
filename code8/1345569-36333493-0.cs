    private static void GetLatest(string username, string password, string path_to_download,
                  string tf_src_path)
        {
    
            Uri collectionUri = new Uri(PathConstants.uri);
            NetworkCredential credential = new NetworkCredential(username, password);
            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri(PathConstants.uri), credential);
            tfs.EnsureAuthenticated();
            VersionControlServer vc = tfs.GetService<VersionControlServer>();
            foreach (Workspace workspace in vc.QueryWorkspaces(null, null, System.Environment.MachineName))
                {
                    foreach (WorkingFolder folder in workspace.Folders)
                    {
                    ItemSpec itemSpec = new ItemSpec(folder.ServerItem,  RecursionType.Full);
                    ItemSpec[] specs = new ItemSpec[] { itemSpec };
                    ExtendedItem[][] extendedItems = workspace.GetExtendedItems(specs, DeletedState.NonDeleted, ItemType.File);
                    ExtendedItem[] extendedItem = extendedItems[0];
                        foreach (var item in extendedItem)
                        {
                            if (item.VersionLocal != item.VersionLatest)
                            {
                                vc.DownloadFile(item.SourceServerItem, item.LocalItem);
                            }
                        }
                    }
                }
            }
