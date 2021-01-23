    //...
    IEnumerable<PriceComparison> priceComparisons =
                  from grouping in groupingsByProductId
                  where grouping.Any(p => p.Distributor == Client)
                  && grouping.Any(p => p.Distributor == competitor)
                  select new PriceComparison
                  {
                     //..
                  };
