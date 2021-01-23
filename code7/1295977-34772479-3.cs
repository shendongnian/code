    public IQueryable<MyEntity> GetLiteMyEntities(IQueryable<MyEntity> query)
    {
        return from me in query 
    		select new MyEntity {Id = x.Id, Name = x.Name, Email = x.Email };
    }
    
    // build your filter first
    from x in MyEntity 
    where x.someSpecialID == 42
    select x;
    
    // then pass it to get your lite object
    var lite = GetLiteMyEntities(x);
