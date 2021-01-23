    public static class TypeTrtansactionExtensions
    {
        public static IEnumerable<PayTransactionsCommand> ToPayTransaction(this IQueryable<TypeTrtansaction> query, string itemName)
        {
            return query.GroupBy(x => new { x.TypeId, x.AccountId })
                    .AsEnumerable()
                    .Select(y => new PayTransactionsCommand
                    {
                        Id = Guid.NewGuid(),
                        Narration = itemName,
                        AccountId = y.Key.AccountId,
                        Credit = y.Sum(z => z.Credit),
                    });
        }
    }
