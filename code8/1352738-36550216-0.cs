    var clients = cList.GroupBy(x => x.ClientID)
                         .Select(x => new { ClientID = x.Key, AmountTotal = x.Sum(c => c.Amount) })
                         .OrderByDescending(x => x.AmountTotal);
    var topThree = clients.Take(3);
    var others = clients.Except(topThree);
