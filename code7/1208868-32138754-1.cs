    var applications = db.ElmahErrors.Where(s => s.Application.Replace("/", "").Replace(".", "") == queryString)
         .GroupBy(s => new { s.Type, s.ID, s.Application, s.Host })
         .Select(grp => new ElmahErrorViewModel {
               ID = grp.Key.ID,
               Application = grp.Key.Application,
               Host = grp.Key.Host,
               Type = grp.Key.Type,
               ErrorCount = grp.Count(),
               Min = grp.Min(m => m.TimeUtc),
               Max = grp.Max(m => m.TimeUtc),
         });
