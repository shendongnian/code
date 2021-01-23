    from d in alliance.SupplierSearchByReviewPeriod
    where d.ClientID == ClientID && ReviewPeriodIDs.Contains((int)d.ReviewPeriodID)
    group d by 0 into g
    select new
    {
        APLReasons = g.Select(d => d.APLReason).Distinct(),
        AreaDescs = g.Select(d => d.Area).Distinct(),
        DeptNames = g.Select(d => d.DeptName).Distinct(),
        StatusCategoryDescs = g.Select(d => d.StatusCategoryDesc).Distinct(),
    }
