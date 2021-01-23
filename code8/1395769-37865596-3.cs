    public ApplicationDbContext DbContext
    {
        get
        {
            if(_dbContext == null)
                _dbContext = ApplicationDbContext.Create();
            return _dbContext;
        }    
    }
