    var lst = new List<string>
    {
      "AAA", "BBB", "CCC", "DDD"
    };
    
    var items = Session.Query<TableA>
      .Where(x => lst.Contains(x.Description))
      .ToList();
