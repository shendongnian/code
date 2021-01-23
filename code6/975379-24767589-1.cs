     var months = Enumerable.Range(1, 12).Select(m=> new {Month = m});
     var max = DateTime.Now.AddYears(-1);
     var result = data.Where(d => d.OrderDate >= max)
                    .GroupBy(d => d.ProductCategory)
                    .Select(g =>
                            new
                            {
                                Name = g.Key,
                                Data =( 
                                from m in months
                                join  d in
                                    g.OrderBy(gg => gg.OrderDate.Year)
                                    .ThenBy(gg => gg.OrderDate.Month)
                                    .GroupBy(gg => gg.OrderDate.Month)
                                    on m.Month equals d.Key into gj
                                    from j in gj.DefaultIfEmpty()
                                        select j != null ? j.Count() : 0)
                            }).ToList();
