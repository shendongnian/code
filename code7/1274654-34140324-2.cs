    .Select(g => new PlatypusData
        {
            MemberName = g.Key.MemberName,
            CompanyName = g.Key.CompanyName,
            ReasonDescription = g.Key.ReasonDescription,
            TransactionType = g.Key.TransactionType,
            QtyOrdered = g.Sum(i => i.QtyOrdered),
            QtyShipped = g.Sum(i => i.QtyShipped)
        })
