    cx.CaseAttorneys
          .Where(o => o.Case.OpeningDate >= startDate && o.Case.OpeningDate <= endDate)
          .GroupBy(o => new { AttorneyID = o.AttorneyID })
          .Select(g => new { AttorneyID = g.Key.AttorneyID,
              ActiveStart = g.Sum(item => item.DateAssigned < startDate && (item.DateUnassigned == null || item.DateUnassigned >= startDate) ? 1 : 0),
              Assigned = g.Sum(item => item.DateAssigned >= startDate && item.DateAssigned <= endDate ? 1 : 0),
              Probation = g.Sum(item => item.DateAssigned >= startDate && item.DateAssigned <= endDate && item.Case.CaseTypeID == 4 ? 1 : 0)
         }).ToArray();
