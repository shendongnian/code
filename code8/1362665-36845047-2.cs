    // Business Logic :
    var transaction = Db.Database.BeginTransaction())
    try {
         _Repository.MethodA();
         _Repository.MethodB();
         transaction.Commit();
    }
    catch(){
         transaction.Rollback();
    }
    //Repository :
    public void MethodA(){
        var tableARecord = new TableARecord();
        _context.TableAs.Add(tableARecord)
        Db.SaveChanges();
    }
    public void MethodA(){
        // Just do some other stuff
        Db.SaveChanges();
    }
