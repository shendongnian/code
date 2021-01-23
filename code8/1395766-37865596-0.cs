    public ApplicationDbContext DbContext
    {
        get
        {
            return _dbContext ?? ApplicationDbContext.Create();
        }
        private set
        {
            _dbContext = value;
        }
    
    }
