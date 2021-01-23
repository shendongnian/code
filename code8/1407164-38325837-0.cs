    public class HiJumpNserviceBusUnitOfWork : IManageUnitsOfWork
    {
        private readonly IUnitOfWork _uow;
        public HiJumpNserviceBusUnitOfWork(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Begin()
        {
            _uow.ClearCache();
            _uow.BeginTransaction();
        }
        public void End(Exception ex = null)
        {
            if (ex != null)
            {
                _uow.ClearCache();
            }
            else
            {
                _uow.CommitTransaction();
            }
        }
    }
