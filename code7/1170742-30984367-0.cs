    return x.Where(r => r.ReviewID == 37)
            .GroupBy(r => new { r.DepartmentID, r.ReviewID, r.ClientID })
            .Select(g => new DepartmentBreakdownReport
                             {
                                 ClientID = g.Key.ClientID,
                                 ReviewID = g.Key.ReviewID,
                                 Dept = g.Max(d => d.DepartmentName),
                                 Amount = g.Sum(d => d.Amount)
                             })
            .OrderBy(r => r.Dept);
