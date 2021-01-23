    public static class BankExtensions {
      public static IQueryable<Summary> ToSummary(this IQueryable<Bank> b) {
        b.Select(bank=>new Summary 
            {
                Id = bank.Id,
                Name = bank.Name,
                ItemSummaries = bank.BankChanges
                                    .SelectMany(x => x.BankItems)
                                    .GroupBy(x => x.Item)
                                    .Select(x => new ItemSummary
                                    {
                                        Item = x.Key.Name,
                                        TotalAdded = x.Sum(y => y.Added),
                                        TotalGenerated = x.Sum(y => y.Generated),
                                        Total = x.Sum(y => y.Added) + x.Sum(y => y.Generated)
                                    })
                                    .Where(x => x.Total > 0)
            };
      }
    }
