    var trueIdList = IssueList.OfType<Issue>()
               .GroupBy(c => c.labelId)
               .Select(c => c.OrderBy(o => o.AuditDate).LastOrDefault())
               .Where(c => c.Result)
               .Select(c => c.labelId)
               .ToList();
