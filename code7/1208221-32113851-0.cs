    // Class to store risk type information.
    class RiskTypeItem
    {
        public int ID { get;set; }
        public string Name { get;set;}
    }
    
    // In ViewModel.
    public List<RiskTypeItem> RiskTypes { get; set; }
    // In Controller.
    var riskTypes = _DBContext.RiskTypes.ToList();
    ActionsModel model = new ActionsModel();
    model.RiskTypes = new List<RiskTypeItem>();
    
    foreach(var riskType in riskTypes)
    {
        model.RiskTypes.Add(new RiskTypeItem { ID = riskType.ID, Name = riskType.Name });
    }
    return ActionResult(model);
    
    //In View.
    <ul>
    @foreach(var riskType in Model.RiskTypes)
    {
        <li>@Html.ActionLink(riskType.Name, "ViewRiskTypes", "RiskTypeDetails", new { SelectedRiskTypeID = riskType.ID }, null)</li>
    }
    </ul>
