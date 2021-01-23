    var workflowProvider = item.Database.WorkflowProvider;
    var workflow = workflowProvider.GetWorkflow(item);
    foreach (var version in item.Versions.GetVersions())
    {
        if (workflow.IsApproved(version))
        {
            workflow.Start(version);
        }
    }
    
    PublishManager.PublishItem(item, targets, item.Languages, false, false);
