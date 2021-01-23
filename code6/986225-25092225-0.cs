    var result   = orderForBooks
    .GroupBy(t => t.iTeamId )
    .Select(tm => new ResultObj
            {
                teamid= tm=>tm.iTeamId,
                points = tm.Sum(c => c.Associate_Points)
            }).ToList();
