    IWorkflow[] workflows = Sitecore.Context.Database.WorkflowProvider.GetWorkflows();
    IWorkflow chosenWorkflow = workflows[..]; // choose your worfklow
    WorkflowState[] workflowStates = chosenWorkflow.GetStates();
    foreach (WorkflowState state in workflowStates)
    {
        if (!state.FinalState)
        {
            DataUri[] itemDataUris = chosenWorkflow.GetItems(state.StateID);
            foreach (DataUri uri in itemDataUris)
            {
                Item item = Sitecore.Context.Database.GetItem(uri);
                /* check other conditions - newer version exists etc */
                ChangeWorkflowState(item, newWorkflowStateId);
            }
        }
    }
