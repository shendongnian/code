        var grouped = mymodel.GroupBy(l => new { l.AddressId })
            .Select(g => new
            {
                AddressId = g.Key.AddressId,
                QuotesByCode = g.SelectMany(x => x.Quotes)
                                .GroupBy(x=>x.Code)
                                .Select(grp=>new
                                  {
                                    Code = grp.Key.Code,
                                    SumOfCurrency=grp.Sum(z=>z.Currency)
                                  }).ToList(),
            }).ToList();
