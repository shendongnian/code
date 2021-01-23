    using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted })) 
    {
    	using (var context = new MyDbContext()) 
    	{ 
    		var result = from a in context.table1
    			join b in context.table2 on a.Id equals b.Id
    			// rest of your linq query here.
    		
    	}
    }
