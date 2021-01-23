    NetworkCredential myNetCredentials = new NetworkCredential("******", "******");
    TfsTeamProjectCollection tfsUri = new TfsTeamProjectCollection(new Uri("https://*****.visualstudio.com/DefaultCollection"), myNetCredentials);
    WorkItemStore tfsStore = tfsUri.GetService<WorkItemStore>();
             if (tfsStore == null)
                {
                    throw new Exception("Cannot initialize TFS Store");
                }
    
             Project teamProject = tfsStore.Projects["*****"];
             WorkItemType workItemType = teamProject.WorkItemTypes["Task"];
             WorkItem Task = new WorkItem(workItemType)
                {
                    Title = "APITask",
                };
                Task.Save();
