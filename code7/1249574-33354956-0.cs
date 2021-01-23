    var pageSize=50;
    var cust=...;
    var max=cust.GroupBy(c=>c.CustomerType).Select(c=>c.Count()).Max();
    var dict=Enumerable
      .Range(0,Math.Ceiling((max-1)/pageSize))
      .Select(page=>
        cust.GroupBy(c=>CustomerType)
          .Select(c=>
            c.Skip(Page*pageSize)
              .Take(pageSize))
        .SelectMany(something))
      .ToDictionary(something);
