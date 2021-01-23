    protected void Add<T>(T source, CliCEntities context, bool isNew, EntityState state) where T : class
    {
    	if (isNew)
    	{
    		context.CreateObjectSet<T>().AddObject(source);
    	}
    	else
    	{
    		if (state == EntityState.Detached)
    		{
    			context.CreateObjectSet<T>().Attach(source);
    
    			context.ObjectStateManager.ChangeObjectState(source, EntityState.Modified);
    		}
    	}
    }
