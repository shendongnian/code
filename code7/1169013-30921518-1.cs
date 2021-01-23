    SortedDictionary<DateTime, double> columnInfos = new SortedDictionary<DateTime, double>();
    columnInfos.Add(DateTime.Now, 1);
    columnInfos.Add(DateTime.Now.AddDays(-2), 2);
    columnInfos.Add(DateTime.Now.AddDays(-4), 3);
    columnInfos.Add(DateTime.Now.AddDays(2), 4);
    columnInfos.Add(DateTime.Now.AddDays(4), 5);
    // dates will return a list containing two dates.
    // Now - 2 days and Now - 4 days.
    var dates = FallBetween(columnInfos, DateTime.Now.AddDays(-3));
    // date will return a list containing only one date
    // because there is only one nearing neighbor.
    var date = FallBetween(columnInfos, DateTime.Now.AddDays(30));
