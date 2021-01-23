    var Ids = (
      from x in MyDbContext.MyObject.Select()
      where x.Contains(x.Id)
      select x
    ).ToDictionary(x => x.Key).Keys.ToList();
    
    var myObjects = (
      from y in MyDbContext2.MyObject
      where y => Ids.Contains(y.Id).ToList()
    ).ToList();
    
    return myObjects;
