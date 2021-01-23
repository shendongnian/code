    public IQueryable<MyEntity> GetLiteMyEntities(DbContext c, string Name) // your implementation of DbContext, not actually DbContext
    {
    	return from me in c.MyEntity 
            select new MyEntity {Id = x.Id, Name = x.Name, Email = x.Email };
    }
