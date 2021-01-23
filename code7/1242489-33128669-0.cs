    var stuff = _Repository.Find<Foo>(x => Codes.Contains(x.Code))
                           .GroupJoin(_Repository.Find<Bar>(y => y.GroupingId == groupingId),
                                      x => barId, 
                                      y => Id, 
                                      (x, ys) => new {x, ys});
    foreach(var s in stuff)
    {
       s.x.Bar = s.ys.FirstOrDefault();
    }
