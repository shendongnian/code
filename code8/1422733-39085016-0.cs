	// This is how to return a newly inserted id from EF 6.
	public int AddMyEntity(MyEntity myEntity)
	{
		dbContext.MyEntities.Add(myEntity);
		context.SaveChanges();
		return myEntity.Id;	
	}
	
	// This is how to return a newly inserted id from EF 5.
	public int AddMyEntity(MyEntity myEntity)
	{
		dbContext.MyEntities.Add(myEntity);
		dbContext.SaveChanges();
		dbContext.Entry(myEntity).Reload();
		return myEntity.Id;	
	}	
