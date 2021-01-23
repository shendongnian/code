                var monthlySales = db.Orders
                     .GroupBy(c => new { Year = c.CreateDateTime.Year, Month = c.CreateDateTime.Month })
                     .Select(c => new
                     {
                         Month = c.Key.Month,
                         Year = c.Key.Year,
                         Total = c.Sum(d => d.Total)
                     })
                     .OrderByDescending(a => a.Year)
                     .ThenByDescending(a => a.Month)
                     .ToList();
