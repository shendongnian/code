    void main()
    {
        var firstDayMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var months = Enumerable.Range(0, 12)
                               .Select(firstDayMonth.AddMonths);
        List<SomeDate> SomeDates = new List<SomeDate>()
                                    {
                                        new SomeDate { Id = 1, Month = firstDayMonth.AddMonths(0), Balance = 1m },
                                        new SomeDate { Id = 2, Month = firstDayMonth.AddMonths(2), Balance = 1m },
                                        new SomeDate { Id = 3, Month = firstDayMonth.AddMonths(1), Balance = 6m },
                                        new SomeDate { Id = 4, Month = firstDayMonth.AddMonths(2), Balance = 5m },
                                        new SomeDate { Id = 5, Month = firstDayMonth.AddMonths(3), Balance = 3m },
                                        new SomeDate { Id = 6, Month = firstDayMonth.AddMonths(2), Balance = 2m },
                                        new SomeDate { Id = 7, Month = firstDayMonth.AddMonths(3), Balance = 4m },
                                        new SomeDate { Id = 8, Month = firstDayMonth.AddMonths(1), Balance = 2m },
                                        new SomeDate { Id = 9, Month = firstDayMonth.AddMonths(3), Balance = 3m },
                                    };
        var groupedMonths = SomeDates
                            .GroupBy(c => c.Month)
                            .ToDictionary(g => g.Key, g => g.Sum(s => s.Balance));
        var Projected12MonthsBalance = new List<Tuple<DateTime, decimal>>();
        foreach (var month in months)
        {
            decimal balance;
            if (groupedMonths.TryGetValue(month, out balance))
            {
                Projected12MonthsBalance.Add(new Tuple<DateTime, decimal>(month, balance));
            }
            else
            {
                Projected12MonthsBalance.Add(
                    new Tuple<DateTime, decimal>(
                        month,
                        groupedMonths.OrderBy(g => g.Key.Subtract(month).Duration()).First().Value));
            }
        }
        foreach (var item in Projected12MonthsBalance)
        {
            Console.WriteLine("{0} {1}", item.Item1, item.Item2);
        }
    }
