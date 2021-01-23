    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(GenericRepository<RecordInternetSpeed> repository, InternetSpeedEntities context)
        {
            this.context = context;
            this.InternetSpeedRepository = repository;
        }
    
        private bool disposed = false;
        private InternetSpeedEntities context;
    
        public IGenericRepository<RecordInternetSpeed> InternetSpeedRepository { get; private set; }
    
        ...
    
    } 
