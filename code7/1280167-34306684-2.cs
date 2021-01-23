    public List<CardGrouping> GetCardGrouping(IQueryable<Areas.RetailShop.Models.FPSinformation> queryable, Func<Areas.RetailShop.Models.FPSinformation, int> groupingFunction)
        {
            return queryable.GroupBy(groupingFunction)
                    .Where(x => x.Key != 0)
                    .Select(x => new CardGrouping
                    {
                        Name = x.Key,
                        Count = x.Sum(groupingFunction)
                    }).ToList();
        }
