    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
    {
    	using (var db = new Context()) // your Context
        {
    		db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ErrorCode ON");
            ErrorCode errorCode = db.ErrorCode.First(); // for example
    		foreach (ErrorCode ec in errorCodesStep3.errorcodesUsers)
    	    {
    	        errorCode.ID = ec.ID;
    	        errorCode.ParentID = ec.ParentID;
    	        errorCode.ErrorDescription = ec.ErrorDescription;    
    	        db.ErrorCode.Add(errorCode);
    		}
    		db.SaveChanges();
    		db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ErrorCode OFF");
    		scope.Complete();
    	}
    }
