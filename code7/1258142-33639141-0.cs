    //Base service class to take the unit of work injection
    public abstract class BaseService
        {
        private IUnitOfWork _uow { get; private set; }
    
        public BaseService(IUnitOfWork scope)
        {
          _uow = scope;
        }
    }
