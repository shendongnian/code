    var groupedTransactions=  temp4
                              .Where(x => x.GroupidAvai == x.GroupidPerf &&
                                          x.KeyTimeAvai == x.KeyTimePerf)
                              .GroupBy(x => x.GroupidAvai);
    var greatestByAvai = groupedTransactions
                         .Select(group => group.OrderByDescending(record => record.KeyTimeAvai)
                         .Take(5);
    var greatestByPerf = groupedTransactions
                         .Select(group => group.OrderByDescending(record => record.KeyTimePerf)
                         .Take(5);
    var allTransactions = greatesByAvai.Concat(greatestByPerf);
                         
