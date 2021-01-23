    public IQueryable<MyEntity> GetLiteMyEntities(this IQueryable<MyEntity> query)
    {
        return from me in query 
      		select new MyEntity {Id = x.Id, Name = x.Name, Email = x.Email };
    }
    
    var lite = (from x in MyEntity 
    where x.someSpecialID == 42
    select x).GetLiteMyEntities();
