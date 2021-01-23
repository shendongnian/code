    // GET: odata/Dogs
    [EnableQuery]
    public IQueryable<Dog> Get()
    {
        return db.Dogs;
    }
    // GET: odata/Dogs(5)/Owner
    [EnableQuery]
    public IQueryable<Owner> GetOwner([FromODataUri] int key)
    {
        return db.Dogs.Where(m => m.ID == key).SelectMany(m => m.Owner);
    }
