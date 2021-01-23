    public interface ICustomerUnitOfWork
    {
        
    }
    public class YourFactoryClass
    {
        public YourFactoryClass(string connectionString)
        {
            
        }
        public ICustomerUnitOfWork ResolveCustomerUnitOfWork()
        {
            // Perform runtime configuration
            return unitOfWork;
        }
    }
