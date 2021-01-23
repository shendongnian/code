    result.GroupBy(x => x.CustomerName)
          .Select(x => new CostByItem
          {
              CustomerName = x.Key,
              LineItem = x.GroupBy(y => y.ItemName)
                          .ToDictionary(y => y.Key, y => y.Sum(z => z.Cost)),
              TotalCost = x.Sum(y => y.Cost)
          }).ToList();
