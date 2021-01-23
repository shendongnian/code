    tableA.Select(x=> new { name = x.name,family = x.family,
                            BaseSalary = TableB.Where(y=>y.Aid == x.Aid&&x.FactorName=="BaseSalary").First().Value,
                            Tax = TableB.Where(z=>z.Aid == x.Aid&&x.FactorName=="Tax").First().Value,
                            Insurance = TableB.Where(z=>z.Aid ==x.Aid&&x.FactorName=="Insurance").First().Value
                            //.....
        }).ToList()
