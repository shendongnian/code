    using (var db = new MyDbContext())
    using (var tran = db.Database.BeginTransaction())
    {
        try
        {
    	    Withdraw(srcAcc, amount, db);
    	    Put(destAcc, amount, db);
    
    	    tran.Commit();
        }
        catch
        {
            tran.Rollback();
            throw;
        }
    }
