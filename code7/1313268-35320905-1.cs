    db.CaseAttorneys.Select(item => new
    {
    	Item = item,
    	ActiveStart = item.DateAssigned < startDate && (item.DateUnassigned == null || item.DateUnassigned >= startDate) ? 1 : 0,
    	Assigned = item.DateAssigned >= startDate && item.DateAssigned <= endDate ? 1 : 0
    })
    .GroupBy(o => new
    {
    	AttorneyID = o.Item.AttorneyID
    })
    .Select(g => new
    {
    	AttorneyID = g.Key.AttorneyID,
    	ActiveStart = g.Sum(item => item.ActiveStart),
    	Assigned = g.Sum(item => item.Assigned)
    }).ToArray();
