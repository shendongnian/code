    /// </summary>
    private PriorityDBContext dbContext = new PriorityDBContext();
    
    public UnitOfWork()
    { 
    }
    
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        this.dbContext = (PriorityDBContext)ApplicationDbContext;
    }
