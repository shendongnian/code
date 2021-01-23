    public static WorkflowResult ChangeWorkflowState(Item item, ID workflowStateId)
    {
        using (new EditContext(item))
        {
            item[FieldIDs.WorkflowState] = workflowStateId.ToString();
        }
        return new WorkflowResult(true, "OK", workflowStateId);
    }
    public static WorkflowResult ChangeWorkflowState(Item item, string workflowStateName)
    {
        IWorkflow workflow = item.Database.WorkflowProvider.GetWorkflow(item);
        if (workflow == null)
        {
            return new WorkflowResult(false, "No workflow assigned to item");
        }
        WorkflowState newState = workflow.GetStates()
            .FirstOrDefault(state => state.DisplayName == workflowStateName);
        if (newState == null)
        {
            return new WorkflowResult(false, "Cannot find workflow state " + workflowStateName);
        }
        return ChangeWorkflowState(item, ID.Parse(newState.StateID));
    }
