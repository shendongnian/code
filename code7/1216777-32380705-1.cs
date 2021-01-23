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
                    server
                    .GetBranchHistory(
                        itemSpecs: new[] { new ItemSpec(item.ServerItem, RecursionType.None), },
                        version: VersionSpec.Latest)
                    .Single()
                    .Select(
                        a =>
                            new
                            {
                                a.Relative.BranchToItem.ChangesetId,
                                a.Relative.BranchToItem.CheckinDate,
                                a.Relative.BranchToItem.ServerItem,
                            })
                    .Single())
            .Dump(5);
        }
    }
