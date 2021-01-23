    public IEnumerable<T> GetFirstFive<T>() where T : EntityObject
    {
        Entities dbContext = new Entities();
	    return dbContext.CreateObjectSet<T>.Take(5);
    }
