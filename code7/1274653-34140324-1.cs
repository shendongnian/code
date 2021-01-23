    var result = _platypusDataList
        .GroupBy(i => new { i.MemberName, i.CompanyName, i.ReasonDescription, i.TransactionType })
        .Select(g => new
            {
                g.Key.MemberName,
                g.Key.CompanyName,
                g.Key.ReasonDescription,
                g.Key.TransactionType,
                QtyOrdered = g.Sum(i => i.QtyOrdered),
                QtyShipped = g.Sum(i => i.QtyShipped)
            })
        .OrderBy(i => i.MemberName)
        .ThenBy(i => i.CompanyName)
        .ThenBy(i => i.ReasonDescription)
        .ToList();
