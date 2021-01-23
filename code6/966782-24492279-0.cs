    var tfsUrl = "http://myTfsServer:8080/tfs/defaultcollection";
    var sourceControlRootPath = "$/MyTeamProject";
    var tfsConnection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsUrl));
    var vcs = tfsConnection.GetService<VersionControlServer>();
            
    var changeSets = vcs.QueryHistory(sourceControlRootPath, RecursionType.Full);
    foreach (var c in changeSets)
    {
        var changeSet = vcs.GetChangeset(c.ChangesetId);
        foreach (var change in changeSet.Changes) 
        {
           // All sorts of juicy data in here
        }
    }
