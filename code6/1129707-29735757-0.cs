    var query = from t in ctx.SomeDataEntity
                            group t by new 
                            { 
                                   Year = t.DateAdded.Year, 
                                   Month = t.DateAdded.Month 
                            } into g
                            select new
                            {
                                MonthAndYear = g.Year + "-" + g.Month,
                                Total = g.Sum(t => t.SomeColumn1) +
                                g.Sum(t => t.SomeColumn2) +
                                g.Sum(t => t.SomeColumn3) +
                                g.Sum(t => t.SomeColumn4)
                            };
