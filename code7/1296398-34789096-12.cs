     public class ServiceFactory: IDisposable // hide this behind an interface
    {
        private DatabaseContext _context;
        private IRepositoryDal _repository;
        public ServiceFactory()
        {
             _context = new DatabaseContext();
            _repository = new RepositoryDal(_context);
        }
        public IShelfBll ShelfService()
        {
            return new ShelfBll(_repository);
        }
        public void Dispose()
        {
            _repository.Dispose();
            _context.Dispose();
        }
    }
