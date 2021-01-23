    ActionsModel model = new ActionsModel();
    var riskTypes = _DBContext.RiskTypes.ToList();
    
    foreach(var riskType in riskTypes)
    {
        model.RiskTypes.Add(new RiskTypeItem { ID = riskType.ID, Name = riskType.Name });
    }
    return ActionResult(model);
    
