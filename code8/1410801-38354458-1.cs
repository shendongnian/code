    List<ObjClass> list = new List<ObjClass>();
    int cnt=0;
    foreach (...)
    {
      list.Add(new ObjClass() { ... });
      if (++cnt % 100 == 0) // bunches of 100
      {
        _db.newUserData.AddRange(list);
        successCount += _db.SaveChanges();
        list.Clear();
        // Optional if a HUGE amount of data
        if (cnt % 1000 == 0)
        {
          _db = new MyDbContext();
        } 
      }
    }
    // Don't forget that!
    _db.newUserData.AddRange(list);
    successCount += _db.SaveChanges();
    list.Clear();
