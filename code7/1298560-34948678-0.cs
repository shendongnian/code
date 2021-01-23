    NetworkCredential netCred = new NetworkCredential("altUserName", "altPassword");
    BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
    TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
    tfsCred.AllowInteractive = false;
    
    TfsTeamProjectCollection teamProjectCollection = new TfsTeamProjectCollection(new Uri(teamProjectCollectionUrl), tfsCred);
    teamProjectCollection.Authenticate();
    teamProjectCollection.EnsureAuthenticated();
    
    VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
    
    Workspace workspace = versionControlServer.GetWorkspace(localPath);
    
    // WorkingFolder workfolder = new WorkingFolder(serverPath, localPath);
    // workspace.CreateMapping(workfolder);
    
    GetStatus getStatus = workspace.Get();
