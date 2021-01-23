    var bu = context.BusinessUnitSet.First().ToEntityReference();
    
    var cbg = new ConstraintBasedGroup
    {
        BusinessUnitId = bu,
        Name = "CBG1",
        Constraints = "<Constraints><Constraint><Expression><Body>false</Body><Parameters><Parameter name=\"resource\"/></Parameters></Expression></Constraint></Constraints>"
    };
    var cbgId = OrganizationService.Create(cbg);
    
