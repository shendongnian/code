    Monitor monitor = monitorDao.Get(id);
    if (someStatus)
    {
        using(var tx = session.BeginTransaction()) 
        {
            monitor.status = 1;    // initially monitor.status == 0 in DB
            tx.Commit();
        }
        // Point 1: some codes that might return or throw exception
    }
    else
    {
        using(var tx = session.BeginTransaction()) 
        {
            monitor.status = 2;    // initially monitor.status == 0 in DB
            tx.Commit();
        }
        // Point 2: some codes that might return or throw exception
    }
     using(var tx = session.BeginTransaction()) 
     {
          monitor.status = 3;
          tx.Commit();
     }
