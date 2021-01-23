    tableA.Select(x=> new { name = x.name,family = x.family,
                            BaseSalary = TableB.Where(y=>y.Aid = x.Aid).BaseSalary,
                            Tax = TableB.Where(z=>z.Aid = x.Aid).Tax,
                            Insurance = TableB.Where(z=>z.Aid = x.Aid).Insurance
                            //.....
        }).ToList()
