    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
    
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            // creation of the unit of work
            return new UnitOfWork();
        }
    }
    
