    var result = from l in list
                 group l by new { l.Date.Year,l.Date.Month} into g 
                 select new
                       {
                         Year = g.Key.Year,
                         Month = g.Key.Month,
                         Items = g.ToList()
                        };
