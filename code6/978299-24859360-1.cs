    var collections = db.Collections.Where(x => x.Date_Time.Value.Year == thisYear)
                                    .Select(m => new {
                                        dt = m.Date_Time.Value,
                                        amount = m.Amount
                                    });
    
    var deposits = db.Collections.Where(x => x.Date_Time.Value.Year == thisYear)
                                    .Select(m => new {
                                        dt = m.Date_Time.Value,
                                        amount = m.Amount
                                    });
    
    var result = collections.Union(deposits)
                            .GroupBy(m => m.dt.Month)
                            .Select(g => new {
                                date = g.First().dt.ToString("MM/yyyy"),
                                totalAmount = g.Sum(x => x.amount)
                             });
