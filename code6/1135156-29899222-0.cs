         TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(
              new Uri("http://server:8080/tfs/DefaultCollection"));
        WorkItemStore workItemStore = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
    
    QueryHierarchy queryRoot = workItemStore.Projects[0].QueryHierarchy;
    QueryFolder folder = (QueryFolder) queryRoot["Shared Queries"];
    QueryDefinition query = (QueryDefinition)folder["Active Bugs"];
    queryResults = workItemStore.Query(query.QueryText);
    foreach(WorkItem wi in queryResults)
    {
    
         // Export to Excel
    }
