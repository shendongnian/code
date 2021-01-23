    var query = new[]
    {
        new { Id = 1, PreorderTime = new DateTime(2015, 11, 11), Name = "Jim", MoneyPaid = 0, TotalMoney = 5000 },
        new { Id = 2, PreorderTime = new DateTime(2015, 11, 09), Name = "Sim", MoneyPaid = 500, TotalMoney = 5000 },
        new { Id = 3, PreorderTime = new DateTime(2015, 11, 10), Name = "Sim", MoneyPaid = 1100, TotalMoney = 5000 },
        new { Id = 4, PreorderTime = new DateTime(2015, 11, 19), Name = "Long", MoneyPaid = 3200, TotalMoney = 5000 },
        new { Id = 5, PreorderTime = new DateTime(2015, 11, 29), Name = "Long", MoneyPaid = 200, TotalMoney = 5000 },
        new { Id = 6, PreorderTime = new DateTime(2015, 11, 08), Name = "Long", MoneyPaid = 5000, TotalMoney = 5000 },
        new { Id = 7, PreorderTime = new DateTime(2015, 11, 28), Name = "Long", MoneyPaid = 5000, TotalMoney = 5000 },
    };
    var expiredDate = DateTime.Now.AddDays(-6);
    int pageSize = 3;
    int pageCount = (query.Length + pageSize - 1) / pageSize;
    for (int pageIndex = 1; pageIndex <= pageCount; pageIndex++)
    {
        var page = query
            .OrderBy(o => o.TotalMoney - o.MoneyPaid > 0 ? o.PreorderTime < expiredDate ? 0 : 1 : 2)
            .ThenByDescending(o => o.PreorderTime)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            //.Select(...)
            .ToList();
    }
