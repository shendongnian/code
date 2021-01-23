    ...
    ProjectionList projList = Projections.ProjectionList();
    // just one projected SELECT statement
    projList.Add(Projections.GroupProperty("PaymentOption").As("PaymentOption"));
    // still only one SELECT result
    criteria.SetProjection(projList);
