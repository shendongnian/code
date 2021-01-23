    public static int Update<T>(this T entity) where T : IEntity
    {
        using(var dbContext=new SUContextContainer())
    	{
          var entry = dbContext.Entry(entity);
          dbContext.Set<T>().Attach(entity);
          entry.State = EntityState.Modified;
          return dbContext.SaveChanges();
    	}
    }
    
    public static int Create<T>(this T entity) where T : IEntity
    {
        using(var dbContext=new SUContextContainer())
    	{
          var entry = dbContext.Entry(entity);
          dbContext.Set<T>().Add(entity);
          return dbContext.SaveChanges();
    	}
    }
