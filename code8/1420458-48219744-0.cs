    var result = availableTimes
        .GroupBy(l => new { l.From, l.To })
        .Select(g => new
        {
            Date = g.Key,
            Count = g.Select(l => l.ResourceId).Distinct().Count(),
            Times = g.Select(l => l)     // Add this to capture the times for the group
        })
        .Where(c => c.Count >= numberOfResourcesToBook);
