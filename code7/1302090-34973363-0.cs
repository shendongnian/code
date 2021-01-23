    Site mySite = serverMgr.Sites.Add(strhostname, "http", bindinginfo, "C:\\admin\\" + domain);
    // Clear Applications collection
    mySite.Applications.Clear();
    
    ApplicationPool newPool = serverMgr.ApplicationPools.Add(strhostname);
    newPool.ManagedRuntimeVersion = "v4.0";
    newPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
    
    // Create new root app and specify new application pool
    Application app = mySite.Applications.Add("/", "C:\\admin\\" + domain);
    app.ApplicationPoolName = strhostname;
    
    serverMgr.CommitChanges();
