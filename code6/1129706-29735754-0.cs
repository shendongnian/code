    var query = from t in ctx.SomeDataEntity
                                group t by new { t.DateAdded.Year, t.DateAdded.Month} into g
                                select new
                                {
                                    Year = g.Key.Year,
                                    Month = g.Key.Month,
                                    Total = g.Sum(t => t.SomeColumn1) +
                                    g.Sum(t => t.SomeColumn2) +
                                    g.Sum(t => t.SomeColumn3) +
                                    g.Sum(t => t.SomeColumn4)
                                };
