    return db.StateSuburbLocation
             .Where(l => l.State == state)
             .OrderByDescending(median)
             .Select(l => new TopMediansModel {
                 Median = median,
                 MedianValue = q.GetType().GetProperty(median),
                 MedianSuburb = q.Suburb
              }).Take(10).ToList();
