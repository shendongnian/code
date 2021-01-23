    data.Where(d => d.OrderDate >= DateTime.Now.AddYears(-1))
                    .GroupBy(d => d.ProductCategory)
                    .Select(
                        g =>
                            new
                            {
                                Name = g.Key,
                                Data =
                                    g.OrderBy(gg=>gg.OrderDate.Year).ThenBy(gg=>gg.OrderDate.Month)
                                    .GroupBy(gg => gg.OrderDate.Month)
                                    .Select(xx => xx.Count()) //if only count
                                    //.Select(xx => new {Month = xx.Key, Count = xx.Count()})
                                    .ToArray()
                            });
