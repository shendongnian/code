    using System.Linq;
    dynamic amounts = dataTable
        .AsQueryable()
        .GroupBy(item => item.AccountNumber)
        .Select(list => new{ AccountNumber: list.Key, Amount: list.Count() }).ToList();
