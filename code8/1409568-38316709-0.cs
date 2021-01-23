    var widgets = db.Updates
          .Where(c => c.Sold.Equals(false))
          .GroupBy(c => c.widgetType)       
          .Select(x => x.OrderByDescending(y => y.TimeStamp).First())
          .Join( db.Owners,
                 u => u.ID,
                 o => o.ID,
                 (u, o) => new { o.Name, u.Style }).ToList();
