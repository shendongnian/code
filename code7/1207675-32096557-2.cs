    TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("Uri"));
    tfs.EnsureAuthenticated();
    
    WorkItemStore workitemstore = tfs.GetService<WorkItemStore>();
    QueryHierarchyProvider queryProvider = new QueryHierarchyProvider(workitemstore);
    Project project = workitemstore.Projects["MyProject"];
    var queries = queryProvider.GetQueryHierarchy(project);
