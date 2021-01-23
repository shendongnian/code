    var monthlySales = from c in db.Orders
                       group c by new { y = c.CreateDateTime.Year, m = c.CreateDateTime.Month } into g
                       select new {
                           Total = c.Sum(t => t.Total),
                           Year = g.Key.y,
                           Month = g.Key.m }).ToList();
