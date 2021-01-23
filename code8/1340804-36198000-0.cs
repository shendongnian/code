    var grouping = csvData
      .GroupBy(x => x.Key.MetricInstance.EntityID)
      .Select(grp => new EntityMetricData { 
         entityID = grp.Key, 
         entityMetrics = grp
           .Select(x => new { 
              trm = x.Key, 
              tsd = x.Value })
           .ToList() })
      .ToList();
