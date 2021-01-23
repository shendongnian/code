    //this will start a new transaction
    using (var trans = new TransactionScope(TransactionScopeOption.RequiresNew))
    {
        try
        {
            _context.Herds.Add(herd);
            _context.SaveChanges();
    
            //this will use the "ambient" transaction but can commit separately
            using (wrapperTransaction = new TransactionScope(TransactionScopeOption.Required))
            {
                Proc1Wrapper(herd);
                Proc2Wrapper(herd);
                Proc3Wrapper(herd);
                InsertDefaultOpinionsProc(herd); 
                wrapperTransaction.Commit() //now your default opinions are inserted into the db
            }
    
            //this should return the herd now fully opinionated :)
            herd = _context.Herds.First(o => o.HerdID == herd.ID);
    
            AddOpinionsManually(herd);
    
            _context.SaveChanges();
            trans.Commit();
        }
        catch 
        {
            trans.Rollback();
            throw;  
        }
    }
