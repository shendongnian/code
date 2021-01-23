    using (var dbContextTransaction = entity.Database.BeginTransaction())
    {
    	//your code
    	if() // check condition of true or false
    	{
    		//if still false then
    		dbContextTransaction.Commit();
    	}
    	else
    	{
    		//if turned to true then
            dbContextTransaction.Rollback();
        }
    }
