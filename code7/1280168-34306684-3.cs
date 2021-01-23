    public List<CardGrouping> GetCardGrouping(List<Areas.RetailShop.Models.FPSinformation> queryable,
            Expression<Func<Areas.RetailShop.Models.FPSinformation, string>> groupingFunction,
            Func<Areas.RetailShop.Models.FPSinformation, int> sumFunction)
        {
            if (queryable.AsQueryable() != null)
            {
                var obj = queryable.AsQueryable().GroupBy(groupingFunction);
                var data = queryable.AsQueryable().GroupBy(groupingFunction).Where(x => x.Key != null).Select(x => new CardGrouping
                {
                    Name = x.Key == null ? "" : x.Key.ToString(),
                    Count = x.Sum(sumFunction)
                }).ToList();
                return data;
            }
            return null;
        }
