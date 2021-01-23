    private DatabaseContext _dbContext;
    
    protected DatabaseContext DbContext
    {
        get { return this._dbContext ?? (this._dbContext = new DatabaseContext()); }
    }
