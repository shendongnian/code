    List<string> projectList = ConfigurationManager.AppSettings["Projects"].Split(',').ToList();
    foreach (string project in projectList)
    {
        Uri uri = new Uri(ConfigurationManager.AppSettings["TFSURI"] + "//" + project);
        TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(uri);
        WorkItemStore workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
        WorkItemCollection workItemCollection = workItemStore.Query("SELECT * FROM WorkItems");
        Parallel.For(0, workItemCollection.Count, (i) =>
        {
           workItemCollection[i].Open();
           WorkItem.ProcessWorkItem(project, workItemCollection[i]);
        });
    }
