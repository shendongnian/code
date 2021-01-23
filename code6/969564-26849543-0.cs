    List<DebtCreditorRPT> groupedList = nonGroupedList.GroupBy(i => new 
      { 
        i.Memberid, 
        i.Name
      }).Select(g => new DebtCreditorRPT 
      {
        Name = g.Key.Name,
        Amount = g.Sum(x => double.Parse(x.Amount)).ToString(), 
        Memberid = g.Key.Memberid
      }).ToList();
