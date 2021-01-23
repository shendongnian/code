    private readonly IRepository<Subsite> _subsiteRepository;
    
    public PlatformService(IUnitOfWork<PlatformContext> unitOfWork)
    {
        _subsiteRepository = unitOfWork.GetRepository<Subsite>();
    }
    
    internal PlatformSerice(Subsite subsiteRepository ) 
    {
        _subsiteRepository = subsiteRepository;
    }
