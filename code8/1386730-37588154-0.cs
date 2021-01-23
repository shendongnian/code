    if (logicalDuplicate != null)
    {
        dbcontext.Entry(logicalDuplicate).State = EntityState.Detached;
        dbcontext.MyEntity.Attach(entity);
		dbcontext.Entry(entity).State = EntityState.Modified;
    }
    else
    {
        dbcontext.MyEntity.Add(entity);
    }
    
	
