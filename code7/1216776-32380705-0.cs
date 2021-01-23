    void Main()
    {
        const String CollectionAddress = "http://tfs:8080/tfs/DefaultCollection";
    
        using (var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(CollectionAddress)))
        {
            tfs.EnsureAuthenticated();
            var server = tfs.GetService<VersionControlServer>();
    
            server.GetItems(
                path: "$/Code/",
                version: VersionSpec.Latest,
                recursion: RecursionType.Full,
                deletedState: DeletedState.NonDeleted,
                itemType: ItemType.File)
            .Items
            .Select(
                item =>
                    server.QueryHistory(
                        path: item.ServerItem,
                        version: VersionSpec.Latest,
                        deletionId: 0,
                        recursion: RecursionType.None,
                        user: "",
                        versionFrom: VersionSpec.ParseSingleSpec("1", ""),
                        versionTo: VersionSpec.Latest,
                        maxCount: 1,
                        includeChanges: false,
                        slotMode: false,
                        includeDownloadInfo: false,
                        sortAscending: true)
                        .Cast<Changeset>()
                        .Select(
                            cs =>
                                new
                                {
                                    cs.ChangesetId,
                                    cs.CreationDate,
                                    item.ServerItem,
                                })
                        .FirstOrDefault())
            .Dump(1);
        }
    }
