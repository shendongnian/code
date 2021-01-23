    var list = listP.Concat(listE)
                    .GroupBy(r => new { r.Status, r.ContractNumber })
                    .Select(g => new Report {
                         Status = g.Key.Status,
                         ContractNumber = g.Key.ContractNumber,
                         Count = g.Sum(r => r.Count)
                    });
