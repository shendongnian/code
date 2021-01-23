    public async Task MethodA()
    {
    	using(var transaction = await context.BeginTransaction() )
    	{
    		await MethodB(transaction);
    		
    		//...
    		
    		transaction.Commit();
    	}
    }
    
    public async Task MethodB(IDbContextTransaction transaction)
    {
        var isOpen = transaction != null;
    
        try
        {
            if (!isOpen)
            {
                transaction = await context.BeginTransaction();
            }
    
            //...
    
            if (!isOpen)
            {
                transaction.Commit();
            }
        }
        finally
        {
            if (!isOpen)
            {
                transaction.Dispose();
            }
        }
    }
    
