    var applicationStepIds = context.ApplicationStepCriterias
                                      .Where(i => i.CriteriaID == selectedCriteria)
                                      .Select(i => i.ApplicationStepID)
                                      .Distinct();
    var applicationIds = context.ApplicationSteps
                                      .Where(i => applicationStepIds.Contains(i.AplicationStepID))
                                      .Select(i => i.AplicationID)
                                      .Distinct();
    var result = context.Applications.Where(i => applicationIds.Contains(i.ApplicationId));
