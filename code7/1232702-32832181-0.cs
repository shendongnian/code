    foreach (var r in actionPlan.Responsibles)
    {
        context.Responsible.Attach(r);
        actionPlan.Responsibles.Add(r);
    }
    context.ActionPlan.Add(actionPlan); 
