    var results = rAssnd
        .GroupBy(s => s.AssigneeId)
        .Select(g => new
        {
            g.Key,
            hasRule = g.Any(s => s.RoleId == proposalRole)
        });
