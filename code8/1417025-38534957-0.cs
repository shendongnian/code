    var groupd = (from a in dbContext.Animals
                  join b in dbContext.ProjectTigers on a.Country equals b.Country
                  select new { Country = a.Country, 
                               No = b.No,
                               Lion = a.Lion, 
                               Tiger = a.Tiger }
                ) // We have the join results. Let's group by now
                .GroupBy(f => f.Country, d => d,
                (key, val) => new { Country = key, 
                                    No = val.First().No,
                                    Lion = val.Sum(s => s.Lion), 
                                    Tiger = val.Sum(g => g.Tiger) });
