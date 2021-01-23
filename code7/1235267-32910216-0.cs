    IQueryable<UrlImages> src;
    switch(something) {
      case 1: src=db.Table1.AsQueryable(); break;
      case 2: src=db.Table2.AsQueryable(); break;
      ...
    }
    var result=src
      .Where(i=>i.DeviceId==deviceId)
      .GroupBy(...)
      .OrderBy(...)
      .Skip(...)
      .Take(...);
