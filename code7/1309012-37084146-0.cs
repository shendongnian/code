    
    var triggers = service.GetEntities<ProcessTrigger>(ProcessTrigger.Fields.ProcessId, workflow.Id, 
                                                       ProcessTrigger.Fields.ControlName, from.LogicalName);
    if (triggers.Count > 0)
    {
        foreach (var trigger in triggers)
        {
            Trace("Updating Trigger {0} for Workflow", trigger.Id);
            service.Update(new ProcessTrigger
            {
                Id = trigger.Id,
                ControlName = to.LogicalName
            });
        }
    }
