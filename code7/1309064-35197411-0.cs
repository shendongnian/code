        TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("URL"));
        WorkItemStore workitemstores = tfs.GetService<WorkItemStore>();
        WorkItem workitem = workitemstores.GetWorkItem(ID);
        if(workitem.Links.Count!=0)
        {
            foreach (Link link in workitem.Links)
            {
                RelatedLink relatedLink = link as RelatedLink;
                if (relatedLink != null)
                {
                    Console.WriteLine(relatedLink.RelatedWorkItemId);
                }
            }
        }
