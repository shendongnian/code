	var centerCodesQuery = db.Centers.CenterCode
        .Select(x => x.CenterCode);
	var query = db.Staging
        .Where(x => !centerCodesQuery.Contains(x.CenterCode))
        .Select(x => x.CenterCode)
        .Distinct();
    var c = query.Count();
